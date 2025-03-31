using SeminarskaPRG_35240340.Komponente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskaPRG_35240340
{

    // Vmesnik za sledenje komponentam vozila.

    // Vmesnik za sledenje komponentam vozila.
    public interface IShranljivost
    {
        bool Shranjeno { get; set; }
        // Vrne serijsko številko ali ID komponente.
        string PridobiShranljiviString();

    }

    // Vmesnik za analizo podatkov o komponentah in napakah.
    public interface IAnaliza
    {
        // Analizira napake in preveri njihovo resnost.
        void AnalizirajNapake(List<NapakaVozila> napake);

        // Izračuna povprečno ceno vseh komponent.
        decimal IzracunajPovprecnoCeno(List<KomponentaVozila> komponente);
    }

    // Vmesnik za uporabo različnih strategij analize napak.
    public interface IStrategijaAnalize
    {
        // Izvede analizo na podlagi izbrane strategije.
        void Analiziraj(List<NapakaVozila> napake);
    }
}