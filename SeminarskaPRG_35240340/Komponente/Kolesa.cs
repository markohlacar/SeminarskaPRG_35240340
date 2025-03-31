using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskaPRG_35240340.Komponente
{

    // Razred, ki predstavlja kolesa vozila.
    // Deduje iz razreda KomponentaVozila.

    public class Kolesa : KomponentaVozila
    {
        // Lastnosti specifične za kolesa
        public int Premer { get; set; }  // Velikost kolesa v palcih
        public string TipPnevmatike { get; set; }  // Tip pnevmatike (npr. letna, zimska)
        public string MaterialPlatisca { get; set; }  // Material platišča (npr. aluminij, jeklo)

        // Glavni konstruktor (brez konzolnih vnosov!)
        public Kolesa(string naziv, string proizvajalec, decimal cena, DateTime datumProizvodnje,
                      string serijskaStevilka, int premer, string tipPnevmatike, string materialPlatisca)
            : base(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka)
        {
            Premer = premer;
            TipPnevmatike = tipPnevmatike;
            MaterialPlatisca = materialPlatisca;
        }

        // Privzeti konstruktor za vnos podatkov iz konzole
        public Kolesa() : base()
        {
            while (true)
            {
                Console.Write("Vnesite premer koles (v colah, npr. 15, 16, 17, 18, 19): ");
                if (int.TryParse(Console.ReadLine(), out int premer) && premer >= 10 && premer <= 22)
                {
                    Premer = premer;
                    break;
                }
                else
                {
                    Console.WriteLine("Napaka: Vnesite število med 10 in 22 col. Poskusite znova.");
                }
            }

            while (true)
            {
                Console.Write("Vnesite tip pnevmatike (Letna, Zimska, Celoletna): ");
                TipPnevmatike = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(TipPnevmatike))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Napaka: Tip pnevmatike ne sme biti prazen. Poskusite znova.");
                }
            }

            while (true)
            {
                Console.Write("Vnesite material platišča (Aluminij, Jeklo, Karbon): ");
                MaterialPlatisca = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(MaterialPlatisca))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Napaka: Material platišča ne sme biti prazen. Poskusite znova.");
                }
            }
        }

        // Metoda za validacijo koles
        public override bool ValidirajKomponento()
        {
            if (Premer < 10 || Premer > 30) return false;
            if (string.IsNullOrWhiteSpace(TipPnevmatike)) return false;
            if (string.IsNullOrWhiteSpace(MaterialPlatisca)) return false;
            return true;
        }

        // Izpis podatkov o kolesih
        public override string IzpisiPodatke()
        {
            return $"{base.ToString()}\n" +
                   $"Premer: {Premer}''\n" +
                   $"Tip pnevmatike: {TipPnevmatike}\n" +
                   $"Material platišča: {MaterialPlatisca}";
        }

        // Preglasitev metode ToString
        public override string ToString()
        {
            return IzpisiPodatke();
        }

        public override string PridobiShranljiviString()
        {
            string baseString = base.PridobiShranljiviString();
            EKomponente tip;
            Enum.TryParse<EKomponente>(this.GetType().Name, out tip);
            return $"{(int)tip},{baseString},{Premer},{TipPnevmatike},{MaterialPlatisca}";
        }
    }
}