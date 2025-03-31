using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using SeminarskaPRG_35240340.Komponente;

namespace SeminarskaPRG_35240340
{
    public class UrejanjePodatkov
    {
        private static readonly UrejanjePodatkov _instanca = new UrejanjePodatkov(); // Singleton
        private static readonly object _lock = new object(); // Sinhronizacija niti

        private readonly string datotekaKomponent = "komponente.txt";
        private readonly string datotekaNapak = "napake.txt";

        // Privatni konstruktor (Singleton vzorec)
        private UrejanjePodatkov() { }

        // Dostop do edine instance
        public static UrejanjePodatkov Instanca
        {
            get
            {
                lock (_lock)
                {
                    return _instanca;
                }
            }
        }

        // Shrani vse komponente v datoteko (asinhrono, paralelno)
        public async Task ShraniKomponenteAsync(List<KomponentaVozila> komponente)
        {
            if (komponente == null || komponente.Count == 0)
            {
                Console.WriteLine("Ni komponent za shranjevanje.");
                return;
            }

            await Task.Run(() =>
            {
                lock (_lock)
                {
                    using (StreamWriter sw = new StreamWriter(datotekaKomponent, false))
                    {
                        foreach (var komponenta in komponente)
                        {
                            sw.WriteLine(komponenta.PridobiShranljiviString());
                        }
                    }
                }
            });

            Console.WriteLine("Komponente uspešno shranjene v datoteko.");
        }

        // Shrani vse napake v datoteko (asinhrono, paralelno)
        public async Task ShraniNapakeAsync(List<NapakaVozila> napake)
        {
            if (napake == null || napake.Count == 0)
            {
                Console.WriteLine("Ni napak za shranjevanje.");
                return;
            }

            await Task.Run(() =>
            {
                lock (_lock)
                {
                    using (StreamWriter sw = new StreamWriter(datotekaNapak, false))
                    {
                        foreach (var napaka in napake)
                        {
                            sw.WriteLine(napaka.PridobiShranljiviString());
                        }
                    }
                }
            });

            Console.WriteLine("✅ Napake uspešno shranjene v datoteko.");
        }

        // Prebere vse komponente iz datoteke (trenutno samo izpiše vsebino)
        public async Task<List<KomponentaVozila>> PreberiKomponenteAsync()
        {
            List<KomponentaVozila> komponente = new List<KomponentaVozila>();
            return await Task.Run(() =>
            {
                lock (_lock)
                {
                    if (!File.Exists(datotekaKomponent))
                    {
                        Console.WriteLine("⚠️ Datoteka za komponente ne obstaja.");
                        return new List<KomponentaVozila>();
                    }

                    var vrstice = File.ReadAllLines(datotekaKomponent).ToList();

                    Console.WriteLine("\n📄 Vsebina datoteke 'komponente.txt':\n");
                    Parallel.ForEach(vrstice, vrstica =>
                    {
                        /*UstvariKomponento(EKomponente tip, string naziv, string proizvajalec, decimal cena, string serijskaStevilka) */
                        string[] vrednosti = vrstica.Split(",");

                        KomponentaVozila? kv = KomponentaFactory.SprocesirajStringArray(vrednosti);
                        if (kv != null)
                        {
                            lock (komponente)
                                komponente.Add(kv);
                        }

                    });

                    // Tukaj lahko dodaš logiko za pretvorbo nazaj v objekte
                    return komponente;
                }
            });
        }

        // Prebere vse napake iz datoteke (trenutno samo izpiše vsebino)
        public async Task<List<NapakaVozila>> PreberiNapakeAsync()
        {
            List<NapakaVozila> napakice = new();
            return await Task.Run(() =>
            {
                lock (_lock)
                {
                    if (!File.Exists(datotekaNapak))
                    {
                        Console.WriteLine("⚠️ Datoteka za napake ne obstaja.");
                        return new List<NapakaVozila>();
                    }

                    var vrstice = File.ReadAllLines(datotekaNapak).ToList();

                    Parallel.ForEach(vrstice, vrstica =>
                    {
                        string[] vrednosti = vrstica.Split(",");
                        int stopnjaResnosti = int.Parse(vrednosti[0]);
                        string koda = vrednosti[1];
                        string opis = vrednosti[2];
                        DateTime datum = DateTime.Parse(vrednosti[3]);
                        bool daNe = bool.Parse(vrednosti[4]);

                        NapakaVozila napaka;
                        if (stopnjaResnosti > 3)
                        {
                            napaka = new KriticnaNapaka(koda, opis, stopnjaResnosti, datum, daNe);
                        }
                        else
                        {
                            napaka = new ManjsaNapaka(koda, opis, stopnjaResnosti, datum, daNe);
                        }
                        lock(napakice)
                        {
                            napakice.Add(napaka);
                        }
                    });

                    // Tukaj lahko dodaš logiko za pretvorbo nazaj v objekte
                    return napakice;
                }
            });
        }

        // Izračuna povprečno ceno komponent
        public decimal IzracunajPovprecnoCeno(List<KomponentaVozila> komponente)
        {
            if (komponente == null || komponente.Count == 0)
            {
                Console.WriteLine("⚠️ Ni komponent za izračun povprečne cene.");
                return 0;
            }

            return komponente.Average(k => k.Cena);
        }
    }
}