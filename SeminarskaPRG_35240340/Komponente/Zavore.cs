using System;

namespace SeminarskaPRG_35240340.Komponente
{
    // Razred, ki predstavlja zavore na vozilu.
    public class Zavore : KomponentaVozila
    {
        public string TipZavor { get; set; }
        public string Material { get; set; }
        public bool Obrabljene { get; set; }


        // konstruktor - uporabljen v KomponentaFactory
        public Zavore(string naziv, string proizvajalec, decimal cena, DateTime datumProizvodnje,
                      string serijskaStevilka, string tipZavor, string material, bool obrabljene)
            : base(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka)
        {
            TipZavor = tipZavor;
            Material = material;
            Obrabljene = obrabljene;
        }

        public override bool ValidirajKomponento()
        {
            return Cena > 0 &&
                   !string.IsNullOrWhiteSpace(TipZavor) &&
                   !string.IsNullOrWhiteSpace(Material) &&
                   DatumProizvodnje >= new DateTime(1900, 1, 1) &&
                   DatumProizvodnje <= DateTime.Now;
        }

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
            EKomponente tip = EKomponente.Zavore;
            Enum.TryParse(GetType().Name, out tip);
            return $"{(int)tip},{baseString},{TipZavor},{Material},{Obrabljene}";
        }
    }
}
