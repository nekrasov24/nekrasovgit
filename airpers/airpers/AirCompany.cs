using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Collections;

namespace airpers
{
     public class AirCompany : TruckAir 
    {
        public string CompanyName;

        public AirCompany(string name, string companyName, int capacity, int carrying, int rangeflight, 
            int fuel, int sumcapacity, int sumarrying)
             : base(name, capacity, carrying, rangeflight, fuel)
        {

            CompanyName = companyName;

        }

        


        


       
    }
}
