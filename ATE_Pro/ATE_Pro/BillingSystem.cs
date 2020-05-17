using System;
using System.Linq;
using BillingSystem.Enums;
using BillingSystem.Models.Interfaces;

namespace BillingSystem.Models.Classes
{
    public class BillingSystem : IBillingSystem
    {
        private readonly IInfo<CallInfo> _info;

        public BillingSystem(IInfo<CallInfo> info)
        {
            this._info = info;
        }

        public Report GetReport(int telephoneNumber)
        {
            var calls = this._info.GetInfoList()
                .Where(x => x.MyNumber == telephoneNumber || x.CalledNumber == telephoneNumber)
                .ToList();

            var report = new Report();

            foreach (var call in calls)
            {
                CallType callType;
                int number;
                if (call.MyNumber == telephoneNumber)
                {
                    callType = CallType.OutgoingCall;
                    number = call.CalledNumber;
                }
                else
                {
                    callType = CallType.IncomingCall;
                    number = call.MyNumber;
                }
                var record = new ReportRecord(callType, number, call.BeginCall, new DateTime((call.EndCall - call.BeginCall).Ticks), call.Cost); // TimeSpan.FromTicks((call.EndCall - call.BeginCall).Ticks) .TotalMinutes  
                report.AddRecord(record);
            }
            return report;
        }
    }
}