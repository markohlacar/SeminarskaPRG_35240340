using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SeminarskaPRG_35240340
{

    // Razred za standardno analizo napak na vozilu.
    // Implementira IStrategijaAnalize.

    public class StandardnaAnalizaStrategija : IStrategijaAnalize
    {
        public void Analiziraj(List<NapakaVozila> napake)
        {
            Console.WriteLine("\n⚠️ Standardna analiza: Kritične napake vozila:");

            var kriticneNapake = napake
                .Where(n => n.StopnjaResnosti >= 4)
                .ToList();

            if (!kriticneNapake.Any())
            {
                Console.WriteLine("Ni zaznanih kritičnih napak.");
                return;
            }

            int števec = 1;
            foreach (var napaka in kriticneNapake)
            {
                Console.WriteLine($"\nNapaka #{števec++}:");
                Console.WriteLine(napaka.IzpisiPodrobnosti());
            }
        }
    }
}