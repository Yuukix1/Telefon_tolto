using System;

namespace Telefon_tolto
{
    public class Telefon
    {
        public string Gyartmany;
        public string Modell;
        public int Akkumulator;
        public Tolto Tolto;

        public Telefon(string gyartmany, string modell, int akkumulator)
        {
            Gyartmany = gyartmany;
            Modell = modell;
            Akkumulator = akkumulator;
            Tolto = null;
        }
    }
}
