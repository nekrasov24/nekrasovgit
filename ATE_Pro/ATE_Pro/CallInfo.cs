using System;

namespace BillingSystem.Models.Classes
{
    public class CallInfo
    {
        public Guid Id { get; set; }
        public int MyNumber { get; set; }
        public int CalledNumber { get; set; }
        public DateTime BeginCall { get; set; }
        public DateTime EndCall { get; set; }
        public int Cost { get; set; }

        public CallInfo(int myNumber, int targetNumber, DateTime beginCall)
        {
            Id = Guid.NewGuid();
            MyNumber = myNumber;
            CalledNumber = targetNumber;
            BeginCall = beginCall;
        }
    }
}
