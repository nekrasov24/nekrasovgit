
using System;


namespace airpers
{
    public abstract class Planes 
    {
        public string Name { get; set; } // имя

        public int Capacity { get; set; } // вместимость

        public int RangeFlight { get; set; } // дальность полета

        public int Fuel { get; set; } // горючее

        


        public Planes (string name, int capacity, int rangeflight, int fuel)
        {
            Name = name;

            Capacity = capacity;

            RangeFlight = rangeflight;

            Fuel = fuel;
        }



        



    }
}
