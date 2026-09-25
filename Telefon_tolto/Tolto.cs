using System;

namespace Telefon_tolto
{
    public class Tolto
    {
        public string Gyartmany { get; set; }
        public string Modell { get; set; }
        public int Watt { get; set; }

        public Tolto(string gyartmany, string modell, int watt)
        {
            Gyartmany = gyartmany;
            Modell = modell;
            Watt = watt;
        }
    }
}
