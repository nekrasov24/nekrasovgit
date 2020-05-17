namespace ATEPro
{
    using System;
    using System.Threading;

    using ATE.Models.Classes;
    using ATE.Models.Interfaces;

    using BillingSystem.Enums;
    using BillingSystem.Models.Classes;
    using BillingSystem.Models.Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            IATE ate = new ATE();
            IReportRender render = new ReportRender();
            BillingSystem bs = new BillingSystem(ate);

            IContract c1 = ate.RegisterContract(new Subscriber("John", "Smith"), TariffType.Pro);
            IContract c2 = ate.RegisterContract(new Subscriber("James", "Bond"), TariffType.Pro);
            IContract c3 = ate.RegisterContract(new Subscriber("Jansen", "Born"), TariffType.Pro);

            c1.Subscriber.AddMoney(10);

            var t1 = ate.GetNewTerminal(c1);
            var t2 = ate.GetNewTerminal(c2);
            var t3 = ate.GetNewTerminal(c3);

            t1.ConnectToPort();
            t2.ConnectToPort();
            t3.ConnectToPort();

            t1.Call(t2.TelephoneNumber);
            Thread.Sleep(2000);
            t2.EndCall();
            t3.Call(t1.TelephoneNumber);
            Thread.Sleep(1000);
            t3.EndCall();
            t2.Call(t1.TelephoneNumber);
            Thread.Sleep(3000);
            t1.EndCall();

            t1.Disconnect();
            t2.Disconnect();
            t3.Disconnect();

            t3.Call(t1.TelephoneNumber);

            Console.WriteLine();
            Console.WriteLine("Sorted records:");
            foreach (var item in render.SortCalls(bs.GetReport(t1.TelephoneNumber), TypeSort.SortByCallType))
            {
                Console.WriteLine(
                    "Calls:\n Type {0} |\n Date: {1} |\n Duration: {2:mm:ss} | Cost: {3} | Telephone number: {4}",
                    item.CallType,
                    item.Date,
                    item.Time,
                    item.Cost,
                    item.Number);
            }

            Console.ReadKey();

        }
    }
}