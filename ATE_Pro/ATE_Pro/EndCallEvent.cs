using System;
using System.Collections.Generic;
using System.Text;

namespace ATE.Events
{
    public class EndCallEvent : EventArgs, ICallingEvent
    {
        public Guid Id { get; }
        public int TelephoneNumber { get; }
        public int CalledTelephoneNumber { get; }

        public EndCallEvent(Guid id, int number)
        {
            this.Id = id;
            this.TelephoneNumber = number;
        }
    }
}
