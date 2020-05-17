using BillingSystem.Enums;

namespace BillingSystem.Models.Classes
{
    public class Tariff
    {
        public int CostOfMonth { get; }
        public int CostOfCallPerMinute { get; }
        public int LimitCallInMonth { get; }
        public TariffType TariffType { get; }

        public Tariff(TariffType type)
        {
            TariffType = type;

            switch (TariffType)
            {
                case TariffType.Pro:
                    {
                        CostOfMonth = 30;
                        LimitCallInMonth = 12;
                        CostOfCallPerMinute = 1;
                        break;
                    }
                default:
                    {
                        CostOfMonth = 0;
                        LimitCallInMonth = 0;
                        CostOfCallPerMinute = 0;
                        break;
                    }
            }
        }
    }
}
