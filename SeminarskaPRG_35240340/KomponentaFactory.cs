using SeminarskaPRG_35240340.SeminarskaPRG_35240340;
using SeminarskaPRG_35240340.Komponente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskaPRG_35240340
{

    public static class KomponentaFactory
    {
        // Centralizirana metoda za ustvarjanje komponent
        public static KomponentaVozila UstvariKomponento(
            EKomponente tip, string naziv, string proizvajalec, decimal cena, string serijskaStevilka)
        {
            DateTime datumProizvodnje = DateTime.Now;
            switch (tip)
            {
                case EKomponente.Motor:
                    Console.Write("Prostornina motorja (v litrih, npr. 1.6): ");
                    if (double.TryParse(Console.ReadLine(), out double prostornina))
                    {
                        return new Motor(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka, prostornina);
                    }
                    else
                    {
                        Console.WriteLine("Napaka: Vnesite veljavno število za prostornino motorja.");
                        return null;
                    }

                case EKomponente.Zavore:
                    Console.Write("Tip zavor (Disk/Boben): ");
                    string tipZavor = Console.ReadLine()?.Trim();

                    Console.Write("Material zavor (Jeklo, Karbon, Keramika): ");
                    string materialZavor = Console.ReadLine()?.Trim();

                    Console.Write("Ali so zavore obrabljene? (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out bool obrabljene) &&
                        !string.IsNullOrWhiteSpace(tipZavor) &&
                        !string.IsNullOrWhiteSpace(materialZavor))
                    {
                        return new Zavore(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka,
                                          tipZavor, materialZavor, obrabljene);
                    }
                    else
                    {
                        Console.WriteLine("Napaka: Nepravilen vnos pri zavorah.");
                        return null;
                    }

                case EKomponente.ElektronskaEnota:
                    Console.Write("Vrsta enote (ECU, ABS modul ...): ");
                    string vrstaEnote = Console.ReadLine()?.Trim();

                    Console.Write("Napetost (6V–14V): ");
                    Console.Write("Napetost (6V - 14V): ");
                    bool veljavnaNapetost = int.TryParse(Console.ReadLine(), out int napetost) && napetost >= 6 && napetost <= 14;

                    Console.Write("Je enota programabilna? (true/false): ");
                    bool.TryParse(Console.ReadLine(), out bool jeProgramabilna);

                    if (veljavnaNapetost && !string.IsNullOrWhiteSpace(vrstaEnote))
                    {
                        return new ElektronskaEnota(naziv, proizvajalec, cena, datumProizvodnje,
                                                    serijskaStevilka, vrstaEnote, napetost, jeProgramabilna);
                    }
                    else
                    {
                        Console.WriteLine("Napaka: Nepravilen vnos pri elektronski enoti.");
                        return null;
                    }

                case EKomponente.Kolesa:
                    Console.Write("Premer koles (10–22 col): ");
                    bool veljavenPremer = int.TryParse(Console.ReadLine(), out int premer) && premer >= 10 && premer <= 22;

                    Console.Write("Tip pnevmatike (Letna, Zimska, Celoletna): ");
                    string tipPnevmatike = Console.ReadLine()?.Trim();

                    Console.Write("Material platišča (Aluminij, Jeklo, Karbon): ");
                    string materialPlatisca = Console.ReadLine()?.Trim();

                    if (veljavenPremer && !string.IsNullOrWhiteSpace(tipPnevmatike) && !string.IsNullOrWhiteSpace(materialPlatisca))
                    {
                        return new Kolesa(naziv, proizvajalec, cena, datumProizvodnje,
                                          serijskaStevilka, premer, tipPnevmatike, materialPlatisca);
                    }
                    else
                    {
                        Console.WriteLine("Napaka: Nepravilen vnos pri kolesih.");
                        return null;
                    }

                default:
                    Console.WriteLine($"Napaka: Neznan tip komponente '{tip}'.");
                    return null;
            }
        }

        public static KomponentaVozila? SprocesirajStringArray(string[] vrednosti)
        {
            // Base komponente ; prebere pa ustvari/vrne komponento
            EKomponente tip = (EKomponente)int.Parse(vrednosti[0]);
            string naziv = vrednosti[1];
            string proizvajalec = vrednosti[2];
            decimal cena = decimal.Parse(vrednosti[3]);
            DateTime datumProizvodnje = DateTime.Parse(vrednosti[4]);
            string serijskaStevilka = vrednosti[5];

            switch (tip)
            {
                case EKomponente.Motor:
                    double prostornina = double.Parse(vrednosti[6]);
                    return new Motor(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka, prostornina);

                case EKomponente.Zavore:
                    string tipZavor = vrednosti[6];
                    string material = vrednosti[7];
                    bool obrabljene = bool.Parse(vrednosti[8]);
                    return new Zavore(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka, tipZavor, material, obrabljene);

                case EKomponente.ElektronskaEnota:
                    string vrsta = vrednosti[6];
                    int napetost = int.Parse(vrednosti[7]);
                    bool programerljivost = bool.Parse(vrednosti[8]);
                    return new ElektronskaEnota(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka, vrsta, napetost, programerljivost);

                case EKomponente.Kolesa:
                    int premer = int.Parse(vrednosti[6]);
                    string tipPnj = vrednosti[7];
                    string vrstaPlat = vrednosti[8];
                    return new Kolesa(naziv, proizvajalec, cena, datumProizvodnje, serijskaStevilka, premer, tipPnj, vrstaPlat);

                default:
                    return null;
            }
        }
    }
}
