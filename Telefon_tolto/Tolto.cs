using System;

namespace Telefon_tolto
{
    public class Tolto
    {
        public string Gyartmany;
        public string Modell;
        public int Watt;

        public Tolto(string gyartmany, string modell, int watt)
        {
            Gyartmany = gyartmany;
            Modell = modell;
            Watt = watt;
        }
    }
}
