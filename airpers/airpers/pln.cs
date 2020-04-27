using System;


namespace airpers
{
    public class Planes
    {
        public string Name { get; set; } // имя

        public int Capacity { get; set; } // вместимость

        public int Carrying { get; set; } // грузоподъемность

        public int RangeFlight { get; set; } // дальность полета

        public int Fuel { get; set; } // горючее

       
        public Planes (string name, int capacity, int carrying, int rangeflight, int fuel)
        {
            Name = name;

            Capacity = capacity;

            Carrying = carrying;

            RangeFlight = rangeflight;

            Fuel = fuel;
        }

        



    }
}
