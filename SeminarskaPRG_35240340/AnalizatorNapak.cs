using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskaPRG_35240340
{

    // Razred omogoča analizo napak na vozilu.
    // Uporablja strategijo za analizo napak (Strategy Pattern).

    public class AnalizatorNapak
    {
        private IStrategijaAnalize strategija;

        public AnalizatorNapak(IStrategijaAnalize strategija)
        {
            this.strategija = strategija;
        }

        public void NastaviStrategijo(IStrategijaAnalize strategija)
        {
            this.strategija = strategija;
        }

        public void IzvediAnalizo(List<NapakaVozila> napake)
        {
            strategija.Analiziraj(napake);
        }
    }
}