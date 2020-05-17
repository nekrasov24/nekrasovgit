using System;
using System.Collections.Generic;
using System.Linq;
using ATE.Enums;
using ATE.Events;
using ATE.Models.Interfaces;
using BillingSystem.Enums;
using BillingSystem.Models.Classes;
using BillingSystem.Models.Interfaces;

namespace ATE.Models.Classes
{
    public class ATE : IATE
    {
        private readonly IDictionary<int, Tuple<Port, IContract>> usersData;
        private readonly IList<CallInfo> callList = new List<CallInfo>();

        public ATE()
        {
            this.usersData = new Dictionary<int, Tuple<Port, IContract>>();

        }

        public Terminal GetNewTerminal(IContract contract)
        {
            var newPort = new Port();
            newPort.AnswerEvent += this.CallingTo;
            newPort.CallEvent += this.CallingTo;
            newPort.EndCallEvent += this.CallingTo;
            this.usersData.Add(contract.Number, new Tuple<Port, IContract>(newPort, contract));
            var newTerminal = new Terminal(contract.Number, newPort);

            return newTerminal;
        }

        public IContract RegisterContract(Subscriber subscriber, TariffType type)
        {
            var contract = new Contract(subscriber, type);

            return contract;
        }

        public void CallingTo(object sender, ICallingEvent e)
        {
            if ((this.usersData.ContainsKey(e.CalledTelephoneNumber) && e.CalledTelephoneNumber != e.TelephoneNumber)
                || e is EndCallEvent)
            {
                CallInfo inf = null;
                Port targetPort;
                Port port;
                int number;
                int calledNumber;
                if (e is EndCallEvent)
                {
                    var callListFirst = this.callList.First(x => x.Id.Equals(e.Id));
                    if (callListFirst.MyNumber == e.TelephoneNumber)
                    {
                        targetPort = this.usersData[callListFirst.CalledNumber].Item1;
                        port = this.usersData[callListFirst.MyNumber].Item1;
                        number = callListFirst.MyNumber;
                        calledNumber = callListFirst.CalledNumber;
                    }
                    else
                    {
                        port = this.usersData[callListFirst.CalledNumber].Item1;
                        targetPort = this.usersData[callListFirst.MyNumber].Item1;
                        calledNumber = callListFirst.MyNumber;
                        number = callListFirst.CalledNumber;
                    }
                }
                else
                {
                    targetPort = this.usersData[e.CalledTelephoneNumber].Item1;
                    port = this.usersData[e.TelephoneNumber].Item1;
                    calledNumber = e.CalledTelephoneNumber;
                    number = e.TelephoneNumber;
                }

                if (targetPort.State == PortState.Connect && port.State == PortState.Connect)
                {
                    var tuple = this.usersData[number];
                    var targetTuple = this.usersData[calledNumber];

                    if (e is AnswerEvent answerArgs)
                    {
                        bool any = false;
                        foreach (var item in this.callList)
                        {
                            if (item.Id.Equals(answerArgs.Id))
                            {
                                any = true;
                                break;
                            }
                        }

                        if (!answerArgs.Id.Equals(Guid.Empty) && any)
                        {
                            inf = this.callList.First(x => x.Id.Equals(answerArgs.Id));
                        }

                        if (inf != null)
                        {
                            targetPort.AnswerCall(
                                answerArgs.TelephoneNumber,
                                answerArgs.CalledTelephoneNumber,
                                answerArgs.StateInCall,
                                inf.Id);
                        }
                        else
                        {
                            targetPort.AnswerCall(
                                answerArgs.TelephoneNumber,
                                answerArgs.CalledTelephoneNumber,
                                answerArgs.StateInCall);
                        }
                    }

                    if (e is CallEvent callArgs)
                    {
                        if (tuple.Item2.Subscriber.Money > tuple.Item2.Tariff.CostOfCallPerMinute)
                        {
                            if (callArgs.Id.Equals(Guid.Empty))
                            {
                                inf = new CallInfo(
                                    callArgs.TelephoneNumber,
                                    callArgs.CalledTelephoneNumber,
                                    DateTime.Now);
                                this.callList.Add(inf);
                            }

                            if (!callArgs.Id.Equals(Guid.Empty) && this.callList.Any(x => x.Id.Equals(callArgs.Id)))
                            {
                                inf = this.callList.First(x => x.Id.Equals(callArgs.Id));
                            }

                            if (inf != null)
                            {
                                targetPort.IncomingCall(
                                    callArgs.TelephoneNumber,
                                    callArgs.CalledTelephoneNumber,
                                    inf.Id);
                            }
                            else
                            {
                                targetPort.IncomingCall(callArgs.TelephoneNumber, callArgs.CalledTelephoneNumber);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Terminal with number {0} is not enough money in the account!", callArgs.TelephoneNumber);
                        }
                    }

                    if (e is EndCallEvent args)
                    {
                        inf = this.callList.First(x => x.Id.Equals(args.Id));
                        inf.EndCall = DateTime.Now;
                        var sumOfCall = tuple.Item2.Tariff.CostOfCallPerMinute *
                                        TimeSpan.FromTicks((inf.EndCall - inf.BeginCall).Ticks).TotalMinutes;
                        inf.Cost = (int)sumOfCall;
                        targetTuple.Item2.Subscriber.RemoveMoney(inf.Cost);
                        targetPort.AnswerCall(
                            args.TelephoneNumber,
                            args.CalledTelephoneNumber,
                            CallState.Rejected,
                            inf.Id);
                    }
                }
            }
            else if (!this.usersData.ContainsKey(e.CalledTelephoneNumber))
            {
                Console.WriteLine("You have calling a non-existent number!!!");
            }
            else
            {
                Console.WriteLine("You have calling a your number!!!");
            }
        }

        public IList<CallInfo> GetInfoList()
        {
            return this.callList;
        }

    }
}
