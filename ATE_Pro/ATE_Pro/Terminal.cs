using System;
using ATE.Events;

namespace ATE.Models.Classes
{
    using global::ATE.Enums;

    public class Terminal
    {
        public event EventHandler<CallEvent> CallEvent;
        public event EventHandler<AnswerEvent> AnswerEvent;
        public event EventHandler<EndCallEvent> EndCallEvent;

        private Guid Id { get; set; }

        public int TelephoneNumber { get; }
        private Port TerminalPort { get; }

        public Terminal(int number, Port port)
        {
            this.TelephoneNumber = number;
            this.TerminalPort = port;
        }

        protected virtual void RaiseCallEvent(int calledNumber)
        {
            this.CallEvent?.Invoke(this, new CallEvent(this.TelephoneNumber, calledNumber));
        }

        protected virtual void RaiseAnswerEvent(int calledNumber, CallState state, Guid id)
        {
            this.AnswerEvent?.Invoke(this, new AnswerEvent(id, this.TelephoneNumber, calledNumber, state));
        }

        protected virtual void RaiseEndCallEvent(Guid id)
        {
            this.EndCallEvent?.Invoke(this, new EndCallEvent(id, this.TelephoneNumber));
        }

        public void Call(int calledNumber)
        {
            this.RaiseCallEvent(calledNumber);
        }

        public void TakeIncomingCall(object sender, CallEvent e)
        {
            bool flag = true;
            Id = e.Id;
            Console.WriteLine("Have incoming Call at number: {0} to terminal {1}", e.TelephoneNumber, e.CalledTelephoneNumber);
            while (flag)
            {
                Console.WriteLine("Answer? Y/N");
                char k = Console.ReadKey().KeyChar;
                if (k == 'Y' || k == 'y')
                {
                    flag = false;
                    Console.WriteLine();
                    this.AnswerToCall(e.TelephoneNumber, CallState.Answered, e.Id);
                }
                else if (k == 'N' || k == 'n')
                {
                    flag = false;
                    Console.WriteLine();
                    this.EndCall();
                }
                else
                {
                    flag = true;
                    Console.WriteLine();
                }
            }
        }

        public void ConnectToPort()
        {
            if (this.TerminalPort.Connect(this))
            {
                this.TerminalPort.CallPortEvent += this.TakeIncomingCall;
                this.TerminalPort.AnswerPortEvent += this.TakeAnswer;
            }
        }

        public void Disconnect()
        {
            if (!this.TerminalPort.Disconnect(this))
            {
                this.TerminalPort.CallPortEvent -= this.TakeIncomingCall;
                this.TerminalPort.AnswerPortEvent -= this.TakeAnswer;
            }
        }

        public void AnswerToCall(int target, CallState state, Guid id)
        {
            this.RaiseAnswerEvent(target, state, id);
        }

        public void EndCall()
        {
            this.RaiseEndCallEvent(Id);
        }

        public void TakeAnswer(object sender, AnswerEvent e)
        {
            Id = e.Id;
            if (e.StateInCall == CallState.Answered)
            {
                Console.WriteLine("Terminal with number: {0}, have answer on call a number: {1}", e.TelephoneNumber, e.CalledTelephoneNumber);
            }
            else
            {
                Console.WriteLine("Terminal with number: {0}, have rejected call", e.TelephoneNumber);
            }
        }
    }
}
