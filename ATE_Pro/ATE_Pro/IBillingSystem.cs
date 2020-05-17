using BillingSystem.Models.Classes;

namespace BillingSystem.Models.Interfaces
{
    public interface IBillingSystem
    {
        Report GetReport(int telephoneNumber);
    }
}