using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskaPRG_35240340
{

    // Razred, ki predstavlja manjšo napako vozila, deduje abstraktno iz NapakaVozila


    public class ManjsaNapaka : NapakaVozila
    {
        // Ali je priporočeno servisiranje vozila ? Ne rabimo ustaviti vozilo v tem primeru
        public bool PotrebnoServisiranje { get; set; }

        // Konstruktor osnovni
        public ManjsaNapaka(string kodaNapake, string opisNapake, int stopnjaResnosti, DateTime datumOdkritja, bool potrebnoServisiranje)
            : base(kodaNapake, opisNapake, stopnjaResnosti, datumOdkritja)
        {
            PotrebnoServisiranje = potrebnoServisiranje;
        }

        // Validacija: manjša napaka mora imeti stopnjo resnosti ≤ 3

        public override bool ValidirajNapako()
        {
            return StopnjaResnosti <= 3;
        }

        // Izpis podrobnosti o napaki
        public override string IzpisiPodrobnosti()
        {
            return $"{base.ToString()}\n" +
                   $"Potrebno servisiranje: {(PotrebnoServisiranje ? "Da – priporočamo obisk servisa" : "Ne – spremljajte stanje")}";
        }


        public override string PridobiShranljiviString()
        {
            string baseString = base.PridobiShranljiviString();
            return $"{baseString},{PotrebnoServisiranje}";
        }
    }
}