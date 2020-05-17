
using System.Collections.Generic;

namespace BillingSystem.Models.Interfaces
{
    public interface IInfo<T>
    {
        IList<T> GetInfoList();
    }
}