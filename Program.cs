using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace airpers
{
    class Program
    {
        static void Main(string[] args)
        {
            AirCompany plane1 = new AirCompany("Boeing747", 70, 300, 150, 120, 0, 0);

            AirCompany plane2 = new AirCompany("Boeing737", 90, 320, 170, 110, 0, 0);

            AirCompany plane3 = new AirCompany("Airbus330", 130, 330, 130, 150, 0, 0);

            AirCompany plane4 = new AirCompany("Airbus310", 160, 350, 190, 160, 0, 0);

            var rsum = AirCompany.Summ(plane1, plane2, plane3, plane4); // создал переменную, которая
            // ссылается на метод, чтобы вывести в консоль найденные общую вместимость и грузоподъемность


            int[] acmpn = new int[4]; // создал массив в который поместил дальность полета каждого самолета
            // и отсортировал в порядке возрастания

             int t; 

            acmpn[0] = plane1.RangeFlight;
            acmpn[1] = plane2.RangeFlight;
            acmpn[2] = plane3.RangeFlight;
            acmpn[3] = plane4.RangeFlight;



            for (int i = 0; i < acmpn.Length; i++)
            {
                for (int j = i + 1; j < acmpn.Length; j++)
                {
                    if (acmpn[i] > acmpn[j])
                    {
                        t = acmpn[i];
                        acmpn[i] = acmpn[j];
                        acmpn[j] = t;
                    }
                    
                }


            }

            for (int i = 0; i < acmpn.Length; i++)
            {
                Console.WriteLine(acmpn[i]);
            }










        }
    }
}
