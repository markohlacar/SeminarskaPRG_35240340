using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SeminarskaPRG_35240340.Komponente
{

    // Razred, ki predstavlja zavore na vozilu.
    // Deduje iz razreda KomponentaVozila.

    public class Zavore : KomponentaVozila
    {
        public string TipZavor { get; set; }
        public string Material { get; set; }
        public bool Obrabljene { get; set; }

        // Konstruktor osnovni
        public Zavore(string naziv, string proizvajalec, decimal cena, DateTime datumProizvodnje,
                      string serijskaStevilka, string tipZavor, string material, bool obrabljene)
            : base(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka)
        {
            TipZavor = tipZavor;
            Material = material;
            Obrabljene = obrabljene;
        }

        // Konstruktor za ročni vnos preko konzole ....
        public Zavore() : base()
        {
            Console.Write("Vnesite tip zavor (Disk/Boben): ");
            TipZavor = Console.ReadLine()?.Trim();

            Console.Write("Vnesite material zavor (npr. Jeklo, Karbon, Keramika): ");
            Material = Console.ReadLine()?.Trim();

            while (true)
            {
                Console.Write("Ali so zavore obrabljene? (true/false): ");
                if (bool.TryParse(Console.ReadLine(), out bool obrabljene))
                {
                    Obrabljene = obrabljene;
                    break;
                }
                else
                {
                    Console.WriteLine("Napaka: Vnesite 'true' ali 'false'.");
                }
            }
        }

        // Validacija komponent
        public override bool ValidirajKomponento()
        {
            if (Cena <= 0) return false;

            if (DatumProizvodnje < new DateTime(1900, 1, 1) || DatumProizvodnje > DateTime.Now) return false;

            if (string.IsNullOrWhiteSpace(TipZavor)) return false;

            if (string.IsNullOrWhiteSpace(Material)) return false;

            return true;
        }

        // Izpis podatkov
        public override string IzpisiPodatke()
        {
            return $"{base.ToString()}\n" +
                   $"Tip zavor: {TipZavor}\n" +
                   $"Material: {Material}\n" +
                   $"Obrabljene: {(Obrabljene ? "Da" : "Ne")}";
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
            return $"{(int)tip},{baseString},{TipZavor},{Material},{Obrabljene}";
        }
    }
}