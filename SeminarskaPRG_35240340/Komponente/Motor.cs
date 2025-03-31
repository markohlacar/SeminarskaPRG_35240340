using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskaPRG_35240340.Komponente
{

    // Razred, ki predstavlja motor vozila deduje iz razreda KomponentaVozila

    public class Motor : KomponentaVozila
    {
        // Prostornina motorja v litrih ( 1.6 ... )
        public double ProstorninaMotorja { get; set; }

        // Konstruktor osnovni...
        public Motor(string naziv, string proizvajalec, decimal cena, DateTime datumProizvodnje,
                     string serijskaStevilka, double prostorninaMotorja)
            : base(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka)
        {
            ProstorninaMotorja = prostorninaMotorja;
        }

        // Validacija komponente motorja
        public override bool ValidirajKomponento()
        {
            if (Cena <= 0) return false;

            if (ProstorninaMotorja <= 0 || ProstorninaMotorja > 10) return false;

            if (DatumProizvodnje < new DateTime(1900, 1, 1) || DatumProizvodnje > DateTime.Now) return false;

            return true;
        }

        // Izpis podatkov
        public override string IzpisiPodatke()
        {
            return $"{base.ToString()}\n" +
                   $"Prostornina motorja: {ProstorninaMotorja} L";
        }

        // Preglasitev ToString
        public override string ToString()
        {
            return IzpisiPodatke();
        }

        public override string PridobiShranljiviString()
        {
            string baseString = base.PridobiShranljiviString();
            EKomponente tip;
            Enum.TryParse<EKomponente>(this.GetType().Name, out tip);
            return $"{(int)tip},{baseString},{ProstorninaMotorja}";
        }
    }
}