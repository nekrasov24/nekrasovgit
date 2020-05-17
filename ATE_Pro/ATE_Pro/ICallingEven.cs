using System;
using System.Collections.Generic;
using System.Text;

namespace ATE.Events
{
    public interface ICallingEvent
    {
        Guid Id { get; }
        int TelephoneNumber { get; }
        int CalledTelephoneNumber { get; }

    }
}
