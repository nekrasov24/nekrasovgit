using System;
using System.Collections.Generic;
using System.Text;
using ATE.Enums;

namespace ATE.Events
{

        public class AnswerEvent : EventArgs, ICallingEvent
        {
            public Guid Id { get; }
            public int TelephoneNumber { get; }
            public int CalledTelephoneNumber { get; }
            public CallState StateInCall { get; }

            public AnswerEvent(int number, int target, CallState state)
            {
                this.TelephoneNumber = number;
                this.CalledTelephoneNumber = target;
                this.StateInCall = state;
            }

            public AnswerEvent(Guid id, int number, int target, CallState state)
            {
                this.Id = id;
                this.TelephoneNumber = number;
                this.CalledTelephoneNumber = target;
                this.StateInCall = state;
            }
        }

}
