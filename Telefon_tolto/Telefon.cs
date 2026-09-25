using System;

namespace Telefon_tolto
{
    public class Telefon
    {
        public string Gyartmany { get; set; }
        public string Modell { get; set; }
        public int Akkumulator { get; set; }
        public Tolto Tolto { get; set; }

        public Telefon(string gyartmany, string modell, int akkumulator)
        {
            Gyartmany = gyartmany;
            Modell = modell;
            Akkumulator = akkumulator;
            Tolto = null;
        }

        public void Toltes(int perc)
        {
            if (Tolto == null || Akkumulator >= 100)
                return;

            Akkumulator += perc;
            if (Akkumulator > 100)
                Akkumulator = 100;
        }
    }
}
