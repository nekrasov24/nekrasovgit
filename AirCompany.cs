using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace airpers
{
     public class AirCompany : Planes 
    {
        public int Sumcapacity { get; set; } // общая вместимость

        public int Sumarrying { get; set; } // общая грузоподъемность

        public AirCompany(string name, int capacity, int carrying, int rangeflight, 
            int fuel, int sumcapacity, int sumarrying)
             : base(name, capacity, carrying, rangeflight, fuel)
        {
            Sumcapacity = sumcapacity;

            Sumarrying = sumarrying;

        }

        // рассчитываю общую вместимость и грузоподъемность

        public static AirCompany Summ(AirCompany plane1, AirCompany plane2, AirCompany plane3, AirCompany plane4)
        {
            int sumcapacity = plane1.Capacity + plane2.Capacity + plane3.Capacity + plane4.Capacity;
            int sumarrying = plane1.Carrying + plane2.Carrying + plane3.Carrying + plane4.Carrying;

            // единственное что пришло в голову объявить новый об с найденными параметрами
            var sum = new AirCompany(null, 0, 0, 0, 0, sumcapacity, sumarrying); 

            return sum;
        }





       
    }
}
