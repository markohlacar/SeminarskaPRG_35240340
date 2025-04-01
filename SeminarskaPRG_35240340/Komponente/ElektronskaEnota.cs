using SeminarskaPRG_35240340.Komponente;
using System;

namespace SeminarskaPRG_35240340
{
    // Razred, ki predstavlja elektronsko enoto vozila (ECU, ABS modul...).
    public class ElektronskaEnota : KomponentaVozila
    {
        private int izmerjenaNapetost;

        public string VrstaEnote { get; set; }

        public bool JeProgramabilna { get; set; }

        public int Napetost { get; set; }
       

        // Konstruktor s parametri za uporabo v factory
        public ElektronskaEnota(string naziv, string proizvajalec, decimal cena, DateTime datumProizvodnje,
                                string serijskaStevilka, string vrstaEnote, int napetost, bool jeProgramabilna)
            : base(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka)
        {
            VrstaEnote = vrstaEnote;
            Napetost = napetost;
            JeProgramabilna = jeProgramabilna;
        }


        // Validacija elektronske enote -  preveri osnovne pogoje
        public override bool ValidirajKomponento()
        {
            return Cena > 0 &&
                   Napetost >= 6 && Napetost <= 14 &&
                   !string.IsNullOrWhiteSpace(VrstaEnote);
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
            EKomponente tip = EKomponente.ElektronskaEnota;
            Enum.TryParse(GetType().Name, out tip);
            return $"{(int)tip},{baseString},{VrstaEnote},{Napetost},{JeProgramabilna}";
        }
    }
}