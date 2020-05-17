using ATE.Events;
using ATE.Models.Classes;
using BillingSystem.Enums;
using BillingSystem.Models.Classes;
using BillingSystem.Models.Interfaces;
using Tariff = BillingSystem.Models.Classes.Tariff;

namespace ATE.Models.Interfaces
{
    public interface IATE : IInfo<CallInfo>
    {
        Terminal GetNewTerminal(IContract contract);
        IContract RegisterContract(Subscriber subscriber, TariffType type);
        void CallingTo(object sender, ICallingEvent e);
    }
}
