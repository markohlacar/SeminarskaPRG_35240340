using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskaPRG_35240340.Komponente
{

    // Abstraktna baza za vse komponente vozila (Motor, ElektronskaEnota, Zavore, itd....)

    public abstract class KomponentaVozila : IShranljivost // Deduje vmesnik za pisanje v fajl
    {
        // Osnovne lastnosti, skupne vsem komponentam....
        public string Naziv { get; set; }
        public string Proizvajalec { get; set; }
        public decimal Cena { get; set; }
        public DateTime DatumProizvodnje { get; set; }
        public string SerijskaStevilka { get; set; }
        public bool Shranjeno { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // Glavni konstruktor – uporabi se pri ustvarjanju novih komponent s podatkih
        public KomponentaVozila(string naziv, string proizvajalec, decimal cena, DateTime datumProizvodnje, string serijskaStevilka)
        {
            Naziv = naziv;
            Proizvajalec = proizvajalec;
            Cena = cena;
            DatumProizvodnje = datumProizvodnje;
            SerijskaStevilka = serijskaStevilka;
        }

        // Privzeti konstruktor – uporaben za interaktivni vnos 
        protected KomponentaVozila() { }

        // Abstraktna metoda za validacijo - definirajo jo podrazreedi
        public abstract bool ValidirajKomponento();

        // Abstraktna metoda za izpis podatkov - definirajo jo podrazreedi
        public abstract string IzpisiPodatke();

        // Osnovni izpis informacij o komponenti...
        public override string ToString()
        {
            return $"Naziv: {Naziv}\n" +
                   $"Proizvajalec: {Proizvajalec}\n" +
                   $"Cena: {Cena} €\n" +
                   $"Datum izdelave: {DatumProizvodnje.ToShortDateString()}\n" +
                   $"Serijska številka: {SerijskaStevilka}";
        }

        public virtual string PridobiShranljiviString()
        {
            return $"{Naziv},{Proizvajalec},{Cena},{DatumProizvodnje},{SerijskaStevilka}";
        }
    }


    // ENUM za nastevanje komponent vozila pač po vrsti...
    public enum EKomponente
    {
        Motor = 1,
        Zavore = 2,
        ElektronskaEnota = 3,
        Kolesa = 4
    }
}