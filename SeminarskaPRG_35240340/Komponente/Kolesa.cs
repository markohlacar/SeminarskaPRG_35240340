using System;

namespace SeminarskaPRG_35240340.Komponente
{
    // Razred, ki predstavlja kolesa vozila (platišča + pnevmatike).
    public class Kolesa : KomponentaVozila
    {
        public int Premer { get; set; }  // V colah (npr. 16)
        public string TipPnevmatike { get; set; }  // Letna, zimska, celoletna ...
        public string MaterialPlatisca { get; set; }  // Aluminij, jeklo, karbon ...

        // Glavni konstruktor – uporabi se prek KomponentaFactory
        public Kolesa(string naziv, string proizvajalec, decimal cena, DateTime datumProizvodnje,
                 string serijskaStevilka, int premer, string tipPnevmatike, string materialPlatisca)
       : base(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka)
        {
            Premer = premer;
            TipPnevmatike = tipPnevmatike;
            MaterialPlatisca = materialPlatisca;
        }

        public override bool ValidirajKomponento()
        {
            return Premer >= 10 && Premer <= 30 &&
                   !string.IsNullOrWhiteSpace(TipPnevmatike) &&
                   !string.IsNullOrWhiteSpace(MaterialPlatisca);
        }

        public override string IzpisiPodatke()
        {
            return $"{base.ToString()}\n" +
                   $"Premer: {Premer}''\n" +
                   $"Tip pnevmatike: {TipPnevmatike}\n" +
                   $"Material platišča: {MaterialPlatisca}";
        }

        public override string ToString() => IzpisiPodatke();

        public override string PridobiShranljiviString()
        {
            string baseString = base.PridobiShranljiviString();
            EKomponente tip = EKomponente.Kolesa;
            Enum.TryParse(GetType().Name, out tip);
            return $"{(int)tip},{baseString},{Premer},{TipPnevmatike},{MaterialPlatisca}";
        }
    }
}
