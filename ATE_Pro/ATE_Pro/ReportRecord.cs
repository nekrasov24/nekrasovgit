using System;
using BillingSystem.Enums;

namespace BillingSystem.Models.Classes
{
    public class ReportRecord
    {
        public CallType CallType { get; }
        public int Number { get; }
        public DateTime Date { get; }
        public DateTime Time { get; }
        public int Cost { get; }

        public ReportRecord(CallType callType, int number, DateTime date, DateTime time, int cost)
        {
            CallType = callType;
            Number = number;
            Date = date;
            Time = time;
            Cost = cost;
        }
    }
}