using System;
using BillingSystem.Enums;
using BillingSystem.Models.Interfaces;

namespace BillingSystem.Models.Classes
{
    public class Contract : IContract
    {
        static Random random = new Random();

        public Subscriber Subscriber { get; }
        public int Number { get; }
        public Tariff Tariff { get; }

        public Contract(Subscriber subscriber, TariffType tariffType)
        {
            Subscriber = subscriber;
            Number = random.Next(1000000, 9999999);
            Tariff = new Tariff(tariffType);
        }

    }
}
