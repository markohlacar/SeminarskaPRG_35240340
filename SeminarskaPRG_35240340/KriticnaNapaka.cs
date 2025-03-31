using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeminarskaPRG_35240340
{

    // Razred, ki predstavlja kritično napako vozila, deduje iz abstraktnega razreda NapakaVozila


    public class KriticnaNapaka : NapakaVozila
    {
        // Ali vozilo ni več vozno zaradi napake ?? če je kritična napaka, pač parkiramo :) 
        public bool VoziloNiVozno { get; set; }

        // Konstruktor za inicializacijo kritične napake
        public KriticnaNapaka(string kodaNapake, string opisNapake, int stopnjaResnosti, DateTime datumOdkritja, bool voziloNiVozno)
            : base(kodaNapake, opisNapake, stopnjaResnosti, datumOdkritja)
        {
            VoziloNiVozno = voziloNiVozno;
        }

        // Validacija: napaka je kritična samo, če je stopnja ≥ 4 in vozilo ni vozno
        public override bool ValidirajNapako()
        {
            return StopnjaResnosti >= 4 && VoziloNiVozno;
        }

        // Izpis podrobnosti o napaki
        public override string IzpisiPodrobnosti()
        {
            return $"{base.ToString()}\n" +
                   $"Vozilo ni vozno: {(VoziloNiVozno ? "DA – takoj ustavite vozilo!" : "Ne – previdno nadaljujte")}";
        }
        public override string PridobiShranljiviString()
        {
            string baseString = base.PridobiShranljiviString();
            return $"{baseString},{VoziloNiVozno}";
        }
    }
}