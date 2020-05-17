using System;
using System.Collections.Generic;
using System.Text;

namespace ATE.Events
{
    public class CallEvent : EventArgs, ICallingEvent
    {
        public Guid Id { get; }
        public int TelephoneNumber { get; }
        public int CalledTelephoneNumber { get; }

        public CallEvent(int number, int target)
        {
            this.TelephoneNumber = number;
            this.CalledTelephoneNumber = target;
        }

        public CallEvent(Guid id, int number, int target)
        {
            this.Id = id;
            this.TelephoneNumber = number;
            this.CalledTelephoneNumber = target;

        }
    }
}
