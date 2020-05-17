using BillingSystem.Models.Classes;

namespace BillingSystem.Models.Interfaces
{
    public interface IContract
    {
        Subscriber Subscriber { get; }
        int Number { get; }
        Tariff Tariff { get; }
    }
}
