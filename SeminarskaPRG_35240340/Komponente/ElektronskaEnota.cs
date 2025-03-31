using SeminarskaPRG_35240340.Komponente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SeminarskaPRG_35240340
{

    // Razred, ki predstavlja elektronsko enoto vozila  ECU, ABS modul....).
    // Deduje iz razreda KomponentaVozila.

    namespace SeminarskaPRG_35240340
    {
        public class ElektronskaEnota : KomponentaVozila
        {
            
            private int izmerjenaNapetost;

            public string VrstaEnote { get; set; }

            public bool JeProgramabilna { get; set; }

            public int Napetost
            {
                get => izmerjenaNapetost;
                set
                {
                    if (value >= 6 && value <= 14)
                    {
                        izmerjenaNapetost = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(Napetost), "Napetost mora biti med 6V in 14V!");
                    }
                }
            }

            // Glavni konstruktor
            public ElektronskaEnota(
                string naziv,
                string proizvajalec,
                decimal cena,
                DateTime datumProizvodnje,
                string serijskaStevilka,
                string vrstaEnote,
                int napetost,
                bool jeProgramabilna
            ) : base(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka)
            {
                VrstaEnote = vrstaEnote;
                Napetost = napetost;
                JeProgramabilna = jeProgramabilna;
            }

            // Privzeti konstruktor 
            public ElektronskaEnota() : base()
            {
                Console.Write("Vnesite vrsto enote (ECU, ABS modul, Senzor,....): ");
                VrstaEnote = Console.ReadLine();

                while (true)
                {
                    Console.Write("Vnesite napetost (6V - 14V): ");
                    if (int.TryParse(Console.ReadLine(), out int napetost))
                    {
                        try
                        {
                            Napetost = napetost; 
                            break;
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine($" Napaka: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Napaka: Vnesite celo število za napetost.");
                    }
                }

                while (true)
                {
                    Console.Write("Ali je enota programabilna? (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out bool programabilna))
                    {
                        JeProgramabilna = programabilna;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Napaka: Vnesite 'true' ali 'false'.");
                    }
                }
            }

            // Validacija elektronske enote: preveri osnovne pogoje
            public override bool ValidirajKomponento()
            {
                if (Cena <= 0) return false;
                if (Napetost < 6 || Napetost > 14) return false; 
                if (string.IsNullOrWhiteSpace(VrstaEnote)) return false;

                return true;
            }

            
            public override string IzpisiPodatke()
            {
                return $"{base.ToString()}\n" +
                       $"Vrsta enote: {VrstaEnote}\n" +
                       $"Napetost: {Napetost}V\n" +
                       $"Programabilna: {(JeProgramabilna ? "Da" : "Ne")}";
            }

            
            public override string ToString()
            {
                return IzpisiPodatke();
            }

            public override string PridobiShranljiviString()
            {
                string baseString = base.PridobiShranljiviString();
                EKomponente tip;
                Enum.TryParse<EKomponente>(this.GetType().Name, out tip);
                return $"{(int)tip},{baseString},{VrstaEnote},{Napetost},{JeProgramabilna}";
            }
        }
    }
}