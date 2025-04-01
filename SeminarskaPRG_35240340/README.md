PROJEKT: Sledenje komponent in napak na vozilih v proizvodnem podjetju

Opis:
Projekt v jeziku C#, ki simulira upravljanje komponent vozila, beleženje napak in njihovo analizo.
Aplikacija uporablja objektno usmerjeno zasnovo, sodobne programske vzorce (Factory, Singleton, Strategy)
ter podpira asinhrono programiranje in učinkovito obdelavo podatkov z uporabo struktur List in Dictionary.

------------------------------------------------------------

STRUKTURA PROJEKTA

1. Abstraktni osnovni razredi:

- KomponentaVozila (osnova za vse komponente vozila):
    - Motor
    - Zavore
    - ElektronskaEnota
    - Kolesa

- NapakaVozila (osnova za različne vrste napak):
    - KriticnaNapaka
    - ManjsaNapaka

------------------------------------------------------------

UPORABLJENI PROGRAMSKI VZORCI

1. Factory vzorec – KomponentaFactory
- Uporablja se za ustvarjanje različnih komponent vozila brez neposrednega instanciranja.
- Poenostavi ustvarjanje objektov v glavni metodi (Program.cs).
- Komponente se ustvarjajo dinamično glede na podano vrsto v obliki niza.
- Uporablja se tudi pri ustvarjanju objektov med branjem iz datoteke.

2. Singleton vzorec – UrejanjePodatkov
- Zagotavlja, da obstaja samo ena instanca razreda za branje in shranjevanje podatkov.
- Uporaba v kodi: UrejanjePodatkov.Instanca

3. Strategy vzorec – AnalizatorNapak
- Omogoča izbiro različnih strategij za analizo napak.
- Uporablja se v Program.cs → metoda IzvediAnalizoNapak()

Možne strategije:
- StandardnaAnalizaStrategija() – prikaže samo kritične napake.
- PodrobnaAnalizaStrategija() – prikaže vse napake.

------------------------------------------------------------

PODATKOVNE STRUKTURE

- Dictionary<SerijskaStevilka ali KodaNapake, TValue>
    - Uporablja se za hiter dostop do specifičnih podatkov brez podvajanja ključev.
    - Implementirano v razredu UpravljanjeDictionary.
    - Omogoča iskanje komponent ali napak po ID-ju ali kodi.

    Primer:
        Dictionary<string, KomponentaVozila>

    Razred UpravljanjeDictionary vrne tudi seznam komponent in napak kot List<T> za potrebe:
    - Shranjevanja v datoteko ali bazo
    - Izpisa vseh obstoječih podatkov

------------------------------------------------------------

ASINHRONO IN PARALELNO PROGRAMIRANJE

1. Asinhrone metode (async/await)
- Uporabljene v razredu UrejanjePodatkov
- Omogočajo branje in shranjevanje podatkov brez blokiranja glavne niti

2. Paralelna obdelava – Parallel.ForEach
- Uporabljena v razredu AnalizatorNapak
- Omogoča hkratno analizo več napak
- Izboljša hitrost obdelave večjih seznamov napak

------------------------------------------------------------

OPOMBA:
Projekt omogoča delo s podatki v datotekah (.txt) ali v SQLite bazi.
UpravljanjeDictionary deluje kot pomožna struktura za hitro iskanje in urejanje komponent in napak.

