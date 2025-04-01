using SeminarskaPRG_35240340.Komponente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace SeminarskaPRG_35240340
{
    class Program
    {
        // Singleton vzorec za upravljanje podatkov ...

        static UrejanjePodatkov analiza = UrejanjePodatkov.Instanca;
        static AnalizatorNapak analizator = new AnalizatorNapak(new StandardnaAnalizaStrategija());
        static UpravljanjeDictionary upravljanje = new UpravljanjeDictionary();

        static async Task Main()

        {
            var seznamKomponent = await analiza.PreberiKomponenteAsync(); 
            upravljanje.DodajKomponente(seznamKomponent.ToArray());
            var seznamNapak = await analiza.PreberiNapakeAsync(); 
            upravljanje.DodajNapake(seznamNapak.ToArray());

            // Uporabniški meni se vrti....
            int izbira;
            do
            {
                Console.WriteLine("\nUPORABNIŠKI MENI ");
                Console.WriteLine("1.Dodaj novo komponento");
                Console.WriteLine("2.Dodaj novo napako");
                Console.WriteLine("3.Prikaz vseh komponent");
                Console.WriteLine("4.Prikaz vseh napak");
                Console.WriteLine("5.Analiza napak (izberi strategijo)");
                Console.WriteLine("6.Izračun povprečne cene komponent");
                Console.WriteLine("7.Shrani podatke v datoteko");
                Console.WriteLine("8.Naloži podatke iz datoteke");
                Console.WriteLine("9.Počisti vse podatke iz slovarja");
                Console.WriteLine("10.Brisanje komponente ali napake po ključu");
                Console.WriteLine("11.Izhod");
                

                Console.Write("Izberite možnost: ");

                if (!int.TryParse(Console.ReadLine(), out izbira))
                {
                    Console.WriteLine("Napačna izbira, poskusite znova.");
                    continue;
                }

                switch (izbira)
                {
                    case 1:
                        DodajKomponento();
                        break;
                    case 2:
                        DodajNapako();
                        break;
                    case 3:
                        PrikazVsehKomponent();
                        break;
                    case 4:
                        PrikazVsehNapak();
                        break;
                    case 5:
                        IzvediAnalizoNapak();
                        break;
                    case 6:
                        Console.WriteLine($"\nPovprečna cena komponent: {analiza.IzracunajPovprecnoCeno(upravljanje.VrniVseKomponente()):F2}€");
                        break;
                    case 7:
                        var vseKomponente = upravljanje.VrniVseKomponente();
                        var vseNapake = upravljanje.VrniVseNapake();

                        await analiza.ShraniKomponenteAsync(vseKomponente);
                        await analiza.ShraniNapakeAsync(vseNapake);
                        break;
                   
                    case 8:
                        seznamKomponent = await analiza.PreberiKomponenteAsync();
                        seznamNapak = await analiza.PreberiNapakeAsync();

                        
                        upravljanje.DodajKomponente(seznamKomponent);
                        upravljanje.DodajNapake(seznamNapak);

                        Console.WriteLine("Podatki iz datotek uspešno naloženi.\n");

                        
                        Console.WriteLine("------ PRIKAZ NALOŽENIH KOMPONENT ------");
                        upravljanje.PrikazVsehKomponent();

                        Console.WriteLine("\n------ PRIKAZ NALOŽENIH NAPAK ------");
                        upravljanje.PrikazVsehNapak();
                        break;
                    case 9:
                        upravljanje.PocistiSlovar();
                        break;

                    case 10:
                        Console.WriteLine("Kaj želite izbrisati?");
                        Console.WriteLine("1. Komponento");
                        Console.WriteLine("2. Napako");

                        string izbiraBrisanja = Console.ReadLine();

                        if (izbiraBrisanja == "1")
                        {
                            Console.Write("Vnesite serijsko številko komponente: ");
                            string kljuc = Console.ReadLine();

                            if (upravljanje.OdstraniKomponento(kljuc))
                            {
                                await analiza.ShraniKomponenteAsync(upravljanje.VrniVseKomponente());
                            }
                        }
                        else if (izbiraBrisanja == "2")
                        {
                            Console.Write("Vnesite kodo napake: ");
                            string kljuc = Console.ReadLine();

                            if (upravljanje.OdstraniNapako(kljuc))
                            {
                                await analiza.ShraniNapakeAsync(upravljanje.VrniVseNapake());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Napačna izbira.");
                        }
                        break;
                    case 11:
                        Console.WriteLine("Izhod iz programa...");
                        break;

                    default:
                        Console.WriteLine(" Napačna izbira, poskusite znova.");
                        break;
                    

                }

            } while (izbira != 15);
        }

      

        // DODAJANJE KOMPONENT

        static void DodajKomponento()
        {
            Console.WriteLine("\nIzberite vrsto komponente:");
            Console.WriteLine("1. Motor");
            Console.WriteLine("2. Zavore");
            Console.WriteLine("3. Elektronska enota");
            Console.WriteLine("4. Kolesa");

            if (!int.TryParse(Console.ReadLine(), out int izbira) || izbira < 1 || izbira > 4)
            {
                Console.WriteLine("Napačna izbira!");
                return;
            }

            EKomponente tip = (EKomponente)izbira;

            Console.Write("Naziv: ");
            string? naziv = Console.ReadLine();
            Console.Write("Proizvajalec: ");
            string? proizvajalec = Console.ReadLine();
            Console.Write("Cena (€): ");
            string? cenaInput = Console.ReadLine();
            Console.Write("Serijska številka: ");
            string? serijskaStevilka = Console.ReadLine();

            // Validacija vseh vhodnih podatkov
            if (string.IsNullOrWhiteSpace(naziv) ||
                string.IsNullOrWhiteSpace(proizvajalec) ||
                string.IsNullOrWhiteSpace(serijskaStevilka) ||
                string.IsNullOrWhiteSpace(cenaInput) ||
                !decimal.TryParse(cenaInput, out decimal cena))
            {
                Console.WriteLine("Napaka: Vsi podatki morajo biti pravilno izpolnjeni!");
                return;
            }

            // Factory štos – ustvari komponento
            KomponentaVozila? novaKomponenta = KomponentaFactory.UstvariKomponento(tip, naziv, proizvajalec, cena, serijskaStevilka);

            if (novaKomponenta == null)
            {
                Console.WriteLine("Napaka: Komponenta ni bila ustvarjena zaradi neveljavnih podatkov.");
                return;
            }

            upravljanje.DodajKomponente(novaKomponenta);
        }

        //  DODAJANJE NAPAK



        static void DodajNapako()
        {
            Console.Write("Koda napake: ");
            string? koda = Console.ReadLine();

            Console.Write("Opis napake: ");
            string? opis = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(koda) || string.IsNullOrWhiteSpace(opis))
            {
                Console.WriteLine("Vsi podatki morajo biti vpisani!");
                return;
            }

            Console.Write("Stopnja resnosti (1-5): ");
            if (!int.TryParse(Console.ReadLine(), out int resnost) || resnost < 1 || resnost > 5)
            {
                Console.WriteLine("Napačna stopnja resnosti!");
                return;
            }

            NapakaVozila novaNapaka = (resnost >= 4)
                ? new KriticnaNapaka(koda, opis, resnost, DateTime.Now, true)
                : new ManjsaNapaka(koda, opis, resnost, DateTime.Now, false);

            upravljanje.DodajNapake(novaNapaka);
        }
        //  PRIKAZ KOMPONENT IN NAPAK 

        static void PrikazVsehKomponent()
        {
            upravljanje.PrikazVsehKomponent();
        }

        static void PrikazVsehNapak()
        {
            upravljanje.PrikazVsehNapak();
        }

        //  ANALIZA NAPAK 

        static void IzvediAnalizoNapak()
        {
            Console.WriteLine("\nIzberite način analize napak:");
            Console.WriteLine("1. Standardna analiza (samo kritične napake)");
            Console.WriteLine("2. Podrobna analiza (vse napake)");

            if (!int.TryParse(Console.ReadLine(), out int izbira) || izbira < 1 || izbira > 2)
            {
                Console.WriteLine(" Napačna izbira!");
                return;
            }

            IStrategijaAnalize strategija = izbira switch
            {
                1 => new StandardnaAnalizaStrategija(),
                2 => new PodrobnaAnalizaStrategija(),
                _ => throw new Exception(" Neveljavna izbira!")
            };

            analizator.NastaviStrategijo(strategija);
            analizator.IzvediAnalizo(upravljanje.VrniVseNapake());
        }

        
    }
}
