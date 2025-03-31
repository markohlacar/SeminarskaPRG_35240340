using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskaPRG_35240340
{

    //Abstraktna baza za vse vrste napak vozila.

    public abstract class NapakaVozila: IShranljivost
    {
        // Osnovne lastnosti vsake napake
        public string KodaNapake { get; set; }            // Koda napake (npr. P001)
        public string OpisNapake { get; set; }            // Kratek opis napake
        public int StopnjaResnosti { get; set; }          // Stopnja resnosti (1–5)
        public DateTime DatumOdkritja { get; set; }       // Datum zaznave napake
        public bool Shranjeno { get; set; }

        // Konstruktor
        public NapakaVozila(string kodaNapake, string opisNapake, int stopnjaResnosti, DateTime datumOdkritja)
        {
            KodaNapake = kodaNapake;
            OpisNapake = opisNapake;
            StopnjaResnosti = stopnjaResnosti;
            DatumOdkritja = datumOdkritja;
        }

        // Abstraktna metoda za validacijo napake (podrazredi jo morajo implementirati)
        public abstract bool ValidirajNapako();

        // Abstraktna metoda za izpis podrobnosti o napaki
        public abstract string IzpisiPodrobnosti();

        // Osnovni izpis napake
        public override string ToString()
        {
            return $"Koda napake: {KodaNapake}\n" +
                   $"Opis: {OpisNapake}\n" +
                   $"Stopnja resnosti: {StopnjaResnosti}\n" +
                   $"Datum odkritja: {DatumOdkritja.ToShortDateString()}";
        }

        public virtual string PridobiShranljiviString()
        {
            return $"{StopnjaResnosti},{KodaNapake},{OpisNapake},{DatumOdkritja}";
        }
    }
}