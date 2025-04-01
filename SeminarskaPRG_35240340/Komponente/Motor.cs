using System;

namespace SeminarskaPRG_35240340.Komponente
{
    // Razred, ki predstavlja motor vozila.
    public class Motor : KomponentaVozila
    {
        public double ProstorninaMotorja { get; set; }  // V litrih (npr. 1.6)

        // Konstruktor s parametri – uporabljen v KomponentaFactory
        public Motor(string naziv, string proizvajalec, decimal cena, DateTime datumProizvodnje,
                     string serijskaStevilka, double prostorninaMotorja)
            : base(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka)
        {
            ProstorninaMotorja = prostorninaMotorja;
        }

        public override bool ValidirajKomponento()
        {
            return Cena > 0 &&
                   ProstorninaMotorja > 0 && ProstorninaMotorja <= 10 &&
                   DatumProizvodnje >= new DateTime(1900, 1, 1) &&
                   DatumProizvodnje <= DateTime.Now;
        }

        public override string IzpisiPodatke()
        {
            return $"{base.ToString()}\n" +
                   $"Prostornina motorja: {ProstorninaMotorja} L";
        }

        public override string ToString() 
        {
        return IzpisiPodatke();
        }


        public override string PridobiShranljiviString()
        {
            string baseString = base.PridobiShranljiviString();
            EKomponente tip = EKomponente.Motor;
            Enum.TryParse(GetType().Name, out tip);
            return $"{(int)tip},{baseString},{ProstorninaMotorja}";
        }
    }
}