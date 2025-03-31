using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskaPRG_35240340
{

    // Razred za podrobno analizo napak na vozilu.
    // Implementira IStrategijaAnalize.

    public class PodrobnaAnalizaStrategija : IStrategijaAnalize
    {
        public void Analiziraj(List<NapakaVozila> napake)
        {
            Console.WriteLine("\n🔍 Podrobna analiza: Vse napake vozila:");

            if (napake == null || napake.Count == 0)
            {
                Console.WriteLine("Ni zaznanih napak v sistemu.");
                return;
            }

            int števec = 1;
            foreach (var napaka in napake)
            {
                Console.WriteLine($"\nNapaka #{števec++}:");
                Console.WriteLine(napaka.IzpisiPodrobnosti());
            }
        }
    }
}