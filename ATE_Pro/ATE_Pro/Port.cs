using System;
using ATE.Enums;
using ATE.Events;

namespace ATE.Models.Classes
{
    public class Port
    {
        public PortState State;
        public bool Flag;

        public event EventHandler<CallEvent> CallPortEvent;
        public event EventHandler<AnswerEvent> AnswerPortEvent;
        public event EventHandler<CallEvent> CallEvent;
        public event EventHandler<AnswerEvent> AnswerEvent;

        public event EventHandler<EndCallEvent> EndCallEvent;

        public Port()
        {
            this.State = PortState.Disconnect;
        }

        public bool Connect(Terminal terminal)
        {
            if (State == PortState.Disconnect)
            {
                State = PortState.Connect;
                terminal.CallEvent += CallingTo;
                terminal.AnswerEvent += AnswerTo;
                terminal.EndCallEvent += EndCall;
                Flag = true;
            }
            return Flag;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (State == PortState.Connect)
            {
                State = PortState.Disconnect;
                terminal.CallEvent -= CallingTo;
                terminal.AnswerEvent -= AnswerTo;
                terminal.EndCallEvent -= EndCall;
                Flag = false;
            }
            return false;
        }

        protected virtual void RaiseIncomingCallEvent(int number, int calledNumber)
        {
            this.CallPortEvent?.Invoke(this, new CallEvent(number, calledNumber));
        }

        protected virtual void RaiseIncomingCallEvent(int number, int calledNumber, Guid id)
        {
            this.CallPortEvent?.Invoke(this, new CallEvent(id, number, calledNumber));
        }

        protected virtual void RaiseAnswerCallEvent(int number, int calledNumber, CallState state)
        {
            this.AnswerPortEvent?.Invoke(this, new AnswerEvent(number, calledNumber, state));
        }

        protected virtual void RaiseAnswerCallEvent(int number, int calledNumber, CallState state, Guid id)
        {
            this.AnswerPortEvent?.Invoke(this, new AnswerEvent(id, number, calledNumber, state));
        }

        protected virtual void RaiseCallingToEvent(int number, int calledNumber)
        {
            this.CallEvent?.Invoke(this, new CallEvent(number, calledNumber));
        }

        protected virtual void RaiseAnswerToEvent(AnswerEvent eventArgs)
        {
            this.AnswerEvent?.Invoke(
                this,
                new AnswerEvent(
                    eventArgs.Id,
                    eventArgs.TelephoneNumber,
                eventArgs.CalledTelephoneNumber,
                eventArgs.StateInCall));
        }

        protected virtual void RaiseEndCallEvent(Guid id, int number)
        {
            this.EndCallEvent?.Invoke(this, new EndCallEvent(id, number));
        }

        private void CallingTo(object sender, CallEvent e)
        {
            RaiseCallingToEvent(e.TelephoneNumber, e.CalledTelephoneNumber);
        }

        private void AnswerTo(object sender, AnswerEvent e)
        {
            this.RaiseAnswerToEvent(e);
        }

        private void EndCall(object sender, EndCallEvent e)
        {
            this.RaiseEndCallEvent(e.Id, e.TelephoneNumber);
        }

        public void IncomingCall(int number, int calledNumber)
        {
            this.RaiseIncomingCallEvent(number, calledNumber);
        }

        public void IncomingCall(int number, int calledNumber, Guid id)
        {
            this.RaiseIncomingCallEvent(number, calledNumber, id);
        }

        public void AnswerCall(int number, int calledNumber, CallState state)
        {
            this.RaiseAnswerCallEvent(number, calledNumber, state);
        }

        public void AnswerCall(int number, int calledNumber, CallState state, Guid id)
        {
            this.RaiseAnswerCallEvent(number, calledNumber, state, id);
        }
    }
}
