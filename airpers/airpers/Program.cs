using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Collections;





namespace airpers
{
    class Program
    {
        static void Main(string[] args)
        {
            AirCompany plane1 = new AirCompany("Boeing747", "NordAir", 70, 300, 150, 120, 0, 0);

            AirCompany plane2 = new AirCompany("Boeing737", "NordAir", 90, 320, 170, 110, 0, 0);

            AirCompany plane3 = new AirCompany("Airbus330", "NordAir", 130, 330, 130, 150, 0, 0);

            AirCompany plane4 = new AirCompany("Airbus310", "NordAir", 160, 350, 190, 160, 0, 0);

            //сортирую по дальности полета
            Console.WriteLine("________________");

            int [] rangefl = new int[4];
            rangefl[0] = plane1.RangeFlight;
            rangefl[1] = plane2.RangeFlight;
            rangefl[2] = plane3.RangeFlight;
            rangefl[3] = plane4.RangeFlight;

            Array.Sort(rangefl);

            foreach (int e in rangefl)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("________________");

            // нахождение самолета по заданным параметрам горючего
            Console.WriteLine("Введите минимальное количество потребления горючего");
            string r = Console.ReadLine();
            int min = Convert.ToInt32(r);

            Console.WriteLine("Введите максимальное количество потребления горючего");
            string n = Console.ReadLine();
            int max = Convert.ToInt32(n);

            ArrayList list = new ArrayList();
            list.Add(plane1.Fuel);
            list.Add(plane2.Fuel);
            list.Add(plane3.Fuel);
            list.Add(plane4.Fuel);

            foreach (int i2 in list)
            {
                if (i2 >= min && i2 <= max)
                {
                    Console.WriteLine(plane1.Name);
                }

                else if (i2 >= min && i2 <= max)
                {
                    Console.WriteLine(plane2.Name);
                }

                else if (i2 >= min && i2 <= max)
                {
                    Console.WriteLine(plane3.Name);
                }

                else if (i2 >= min && i2 <= max)
                {
                    Console.WriteLine(plane4.Name);
                }
            }

            Console.WriteLine("________________");

            // нахождение общей грузоподъемности и вместимости
            int sumcapacity = 0;

            List<int> summcpst = new List<int>();
            summcpst.Add(plane1.Capacity);
            summcpst.Add(plane2.Capacity);
            summcpst.Add(plane3.Capacity);
            summcpst.Add(plane4.Capacity);

            foreach (int i3 in summcpst)
            {
                sumcapacity = sumcapacity + i3;
            }

            Console.WriteLine($"Общая вметимость {sumcapacity}");

            Console.WriteLine("________________");

            int sumcarrying = 0;

            List<int> summcrng = new List<int>();
            summcrng.Add(plane1.Carrying);
            summcrng.Add(plane2.Carrying);
            summcrng.Add(plane3.Carrying);
            summcrng.Add(plane4.Carrying);

            foreach (int i3 in summcrng)
            {
                sumcarrying = sumcarrying + i3;
            }

            Console.WriteLine($"Общая грузоподъемность {sumcarrying}");

            Console.WriteLine("________________");


        }
    }
}
