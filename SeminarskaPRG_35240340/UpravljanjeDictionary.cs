using SeminarskaPRG_35240340.Komponente;
using System;
using System.Collections.Generic;

namespace SeminarskaPRG_35240340
{
    public class UpravljanjeDictionary
    {
        // Slovari  za hiter dostop do komponent in napak
        private Dictionary<string, KomponentaVozila> komponentaMap = new Dictionary<string, KomponentaVozila>();
        private Dictionary<string, NapakaVozila> napakaMap = new Dictionary<string, NapakaVozila>();

        // DODAJANJE PODATKOV

        public void DodajKomponente(params KomponentaVozila[] komponente)
        {
            foreach (var komponenta in komponente)
            {
                if (komponenta == null || string.IsNullOrWhiteSpace(komponenta.SerijskaStevilka))
                {
                    Console.WriteLine(" Neveljavna komponenta!");
                    continue;
                }

                if (komponentaMap.ContainsKey(komponenta.SerijskaStevilka))
                {
                    Console.WriteLine($" Komponenta s serijsko številko {komponenta.SerijskaStevilka} že obstaja!");
                    continue;
                }

                komponentaMap[komponenta.SerijskaStevilka] = komponenta;
                Console.WriteLine($" Komponenta {komponenta.Naziv} uspešno dodana!");
            }
        }

        public void DodajNapake(params NapakaVozila[] napake)
        {
            foreach (var napaka in napake)
            {

                if (napaka == null || string.IsNullOrWhiteSpace(napaka.KodaNapake))
                {
                    Console.WriteLine(" Neveljavna napaka!");
                    continue;
                }

                if (napakaMap.ContainsKey(napaka.KodaNapake))
                {
                    Console.WriteLine($" Napaka s kodo {napaka.KodaNapake} že obstaja!");
                    continue;
                }

                napakaMap[napaka.KodaNapake] = napaka;
                Console.WriteLine($" Napaka {napaka.KodaNapake} uspešno dodana!");
            }
        }

        // PRIKAZ PODATKOV

        public void PrikazVsehKomponent()
        {
            if (komponentaMap.Count == 0)
            {
                Console.WriteLine(" Ni vnesenih komponent.");
                return;
            }

            Console.WriteLine("\n Seznam vseh komponent:");
            foreach (var komponenta in komponentaMap.Values)
            {
                Console.WriteLine(komponenta.ToString());
                Console.WriteLine("--------------------------------------------------");
            }
        }

        public void PrikazVsehNapak()
        {
            if (napakaMap.Count == 0)
            {
                Console.WriteLine(" Ni vnesenih napak.");
                return;
            }

            Console.WriteLine("\n Seznam vseh napak:");
            foreach (var napaka in napakaMap.Values)
            {
                Console.WriteLine(napaka.ToString());
                Console.WriteLine("--------------------------------------------------");
            }
        }

        // ISKANJE PODATKOV

        public KomponentaVozila NajdiKomponento(string serijskaStevilka)
        {
            if (komponentaMap.TryGetValue(serijskaStevilka, out var komponenta))
            {
                return komponenta;
            }

            Console.WriteLine($" Komponenta s serijsko številko '{serijskaStevilka}' ni bila najdena.");
            return null;
        }

        public NapakaVozila NajdiNapako(string kodaNapake)
        {
            if (napakaMap.TryGetValue(kodaNapake, out var napaka))
            {
                return napaka;
            }

            Console.WriteLine($" Napaka s kodo '{kodaNapake}' ni bila najdena.");
            return null;
        }

        // BRISANJE PODATKOV

        public bool OdstraniKomponento(string serijskaStevilka)
        {
            if (komponentaMap.Remove(serijskaStevilka))
            {
                Console.WriteLine($" Komponenta {serijskaStevilka} uspešno odstranjena.");
                return true;
            }

            Console.WriteLine($" Komponente s serijsko številko {serijskaStevilka} ni mogoče najti.");
            return false;
        }

        public bool OdstraniNapako(string kodaNapake)
        {
            if (napakaMap.Remove(kodaNapake))
            {
                Console.WriteLine($" Napaka {kodaNapake} uspešno odstranjena.");
                return true;
            }

            Console.WriteLine($"  Napake s kodo {kodaNapake} ni mogoče najti.");
            return false;
        }

        // DOSTOP DO NOTRANJIH SEZNAMOV (če jih rabimo za LINQ ali shranjevanje)

        public List<KomponentaVozila> VrniVseKomponente() => komponentaMap.Values.ToList();
        public List<NapakaVozila> VrniVseNapake() => napakaMap.Values.ToList();
    }
}