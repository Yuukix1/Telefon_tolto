using System;
using System.Collections.Generic;

namespace Telefon_tolto
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ===== 1. ADATOK INICIALIZÁLÁSA =====
            // Telefonok listája létrehozása
            List<Telefon> telefonok = new List<Telefon>();
            telefonok.Add(new Telefon("Samsung", "Galaxy", 30));
            telefonok.Add(new Telefon("Apple", "iPhone", 50));
            telefonok.Add(new Telefon("Xiaomi", "Note", 20));

            // Töltők listája létrehozása
            List<Tolto> toltok = new List<Tolto>();
            toltok.Add(new Tolto("Samsung", "25W", 25));
            toltok.Add(new Tolto("Apple", "20W", 20));
            toltok.Add(new Tolto("Xiaomi", "67W", 67));

            // ===== 2. FŐCIKLUS - A MENÜ =====
            // Végtelenített ciklus amíg a felhasználó ki nem lép
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1 - Telefonok");
                Console.WriteLine("2 - Tolto csatlakoztatas");
                Console.WriteLine("3 - Toltes");
                Console.WriteLine("0 - Kilepes");
                Console.Write("Valasztas: ");

                string input = Console.ReadLine();

                // ===== 3.1 OPCIÓ 1: TELEFONOK LISTÁZÁSA =====
                if (input == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Telefonok:");
                    // Végigmegyünk az összes telefonon
                    for (int i = 0; i < telefonok.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + telefonok[i].Gyartmany + " " + telefonok[i].Modell + " - " + telefonok[i].Akkumulator + "%");
                    }
                    Console.ReadLine();
                }
                // ===== 3.2 OPCIÓ 2: TÖLTŐ CSATLAKOZTATÁSA =====
                else if (input == "2")
                {
                    Console.Clear();
                    // Töltő kiválasztása
                    Console.WriteLine("Tolto valasztasa:");
                    for (int i = 0; i < toltok.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + toltok[i].Gyartmany + " " + toltok[i].Modell + " " + toltok[i].Watt + "W");
                    }
                    Console.Write("Sorszam: ");
                    int toltoIdx = int.Parse(Console.ReadLine()) - 1;

                    // Telefon kiválasztása
                    Console.WriteLine("\nTelefon valasztasa:");
                    for (int i = 0; i < telefonok.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + telefonok[i].Gyartmany + " " + telefonok[i].Modell);
                    }
                    Console.Write("Sorszam: ");
                    int telefonIdx = int.Parse(Console.ReadLine()) - 1;

                    // A kiválasztott telefonhoz hozzárendelünk egy töltőt
                    telefonok[telefonIdx].Tolto = toltok[toltoIdx];
                    Console.WriteLine("Csatlakoztatas keszult!");
                    Console.ReadLine();
                }
                // ===== 3.3 OPCIÓ 3: TÖLTÉS =====
                else if (input == "3")
                {
                    Console.Clear();
                    // Telefon kiválasztása
                    Console.WriteLine("Telefon valasztasa:");
                    for (int i = 0; i < telefonok.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + telefonok[i].Gyartmany + " " + telefonok[i].Modell + " - " + telefonok[i].Akkumulator + "%");
                    }
                    Console.Write("Sorszam: ");
                    int idx = int.Parse(Console.ReadLine()) - 1;

                    // Ellenőrzés: van-e töltő csatlakoztatva?
                    if (telefonok[idx].Tolto == null)
                    {
                        Console.WriteLine("Nincs tolto csatlakoztatva!");
                    }
                    else
                    {
                        // Töltési idő bekérése
                        Console.Write("Hany perc? ");
                        int perc = int.Parse(Console.ReadLine());

                        // Az akkumulátor növelése a percek szerint
                        telefonok[idx].Akkumulator = telefonok[idx].Akkumulator + perc;

                        // Hogy ne menjen 100 fölé, korlátozunk
                        if (telefonok[idx].Akkumulator > 100)
                        {
                            telefonok[idx].Akkumulator = 100;
                        }

                        Console.WriteLine("Toltes kesz! " + telefonok[idx].Akkumulator + "%");
                    }
                    Console.ReadLine();
                }
                // ===== 3.4 OPCIÓ 0: KILÉPÉS =====
                else if (input == "0")
                {
                    break;  // Kilépünk a while ciklusból, vége a programnak
                }
            }
        }
    }
}
