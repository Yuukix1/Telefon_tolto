using System;
using System.Collections.Generic;

namespace Telefon_tolto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Telefon> telefonok = new List<Telefon>
            {
                new Telefon("Samsung", "Galaxy S21", 30),
                new Telefon("Apple", "iPhone 13", 50),
                new Telefon("Xiaomi", "12 Pro", 20)
            };

            List<Tolto> toltok = new List<Tolto>
            {
                new Tolto("Samsung", "25W", 25),
                new Tolto("Apple", "20W", 20),
                new Tolto("Xiaomi", "67W", 67)
            };

            int kivalasztottTelefonIndex = -1;
            bool kilepes = false;

            while (!kilepes)
            {
                Console.Clear();
                Console.WriteLine("=== TELEFON TOLTO SZIMULÁTOR ===\n");

                if (kivalasztottTelefonIndex >= 0)
                {
                    Telefon t = telefonok[kivalasztottTelefonIndex];
                    Console.WriteLine("Jelenlegi: " + t.Gyartmany + " " + t.Modell + " (" + t.Akkumulator + "%)");
                    if (t.Tolto != null)
                        Console.WriteLine("Töltő: " + t.Tolto.Gyartmany + " " + t.Tolto.Modell + "\n");
                    else
                        Console.WriteLine("Töltő: nincs\n");
                }

                Console.WriteLine("1. Telefonok listázása");
                Console.WriteLine("2. Telefon kiválasztása");
                Console.WriteLine("3. Töltő csatlakoztatása");
                Console.WriteLine("4. Töltő lecsatlakoztatása");
                Console.WriteLine("5. Töltés");
                Console.WriteLine("0. Kilépés");
                Console.Write("\nVálasztás: ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int valasztas))
                {
                    Console.WriteLine("Érvénytelen!");
                    Console.ReadLine();
                    continue;
                }

                switch (valasztas)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=== TELEFONOK ===\n");
                        for (int i = 0; i < telefonok.Count; i++)
                        {
                            Telefon t = telefonok[i];
                            string jel = (i == kivalasztottTelefonIndex) ? " *" : "";
                            Console.WriteLine((i + 1) + ". " + t.Gyartmany + " " + t.Modell + " (" + t.Akkumulator + "%)" + jel);
                        }
                        Console.WriteLine("\nENTER...");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("=== TELEFON KIVÁLASZTÁSA ===\n");
                        for (int i = 0; i < telefonok.Count; i++)
                        {
                            Telefon t = telefonok[i];
                            Console.WriteLine((i + 1) + ". " + t.Gyartmany + " " + t.Modell);
                        }
                        Console.Write("\nMelyik? (1-" + telefonok.Count + "): ");
                        if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= telefonok.Count)
                        {
                            kivalasztottTelefonIndex = idx - 1;
                            Console.WriteLine("Kiválasztva!");
                            Console.ReadLine();
                        }
                        else
                            Console.ReadLine();
                        break;

                    case 3:
                        if (kivalasztottTelefonIndex < 0)
                        {
                            Console.WriteLine("Előbb válassz telefont!");
                            Console.ReadLine();
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("=== TÖLTŐ CSATLAKOZTATÁSA ===\n");
                        for (int i = 0; i < toltok.Count; i++)
                        {
                            Tolto to = toltok[i];
                            Console.WriteLine((i + 1) + ". " + to.Gyartmany + " " + to.Modell + " (" + to.Watt + "W)");
                        }
                        Console.Write("\nMelyik? (1-" + toltok.Count + "): ");
                        if (int.TryParse(Console.ReadLine(), out int tidx) && tidx > 0 && tidx <= toltok.Count)
                        {
                            telefonok[kivalasztottTelefonIndex].Tolto = toltok[tidx - 1];
                            Console.WriteLine("Csatlakoztatva!");
                            Console.ReadLine();
                        }
                        else
                            Console.ReadLine();
                        break;

                    case 4:
                        if (kivalasztottTelefonIndex < 0)
                        {
                            Console.WriteLine("Előbb válassz telefont!");
                            Console.ReadLine();
                            break;
                        }
                        telefonok[kivalasztottTelefonIndex].Tolto = null;
                        Console.WriteLine("Lecsatlakoztatva!");
                        Console.ReadLine();
                        break;

                    case 5:
                        if (kivalasztottTelefonIndex < 0)
                        {
                            Console.WriteLine("Előbb válassz telefont!");
                            Console.ReadLine();
                            break;
                        }
                        if (telefonok[kivalasztottTelefonIndex].Tolto == null)
                        {
                            Console.WriteLine("Nincs töltő!");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Hány percig? ");
                        if (int.TryParse(Console.ReadLine(), out int perc) && perc > 0)
                        {
                            telefonok[kivalasztottTelefonIndex].Toltes(perc);
                            Console.WriteLine("Töltés kész: " + telefonok[kivalasztottTelefonIndex].Akkumulator + "%");
                            Console.ReadLine();
                        }
                        else
                            Console.ReadLine();
                        break;

                    case 0:
                        kilepes = true;
                        break;

                    default:
                        Console.WriteLine("Érvénytelen!");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
