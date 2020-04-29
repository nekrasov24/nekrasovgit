using System;


namespace airpers
{
    public class TruckAir : Planes
    {
        public int Carrying { get; set; } // грузоподъемность

        public TruckAir(string name, int capacity, int carrying, int rangeflight, int fuel)
            : base(name, capacity, rangeflight, fuel)
        {
            Carrying = carrying;


        }
    }
}
