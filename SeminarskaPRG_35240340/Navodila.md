PROJEKT: Sledenje komponent in napak na vozilih v proizvodnem podjetju

OPIS: Gre se za enostavno C# konzolno aplikacijo, ki simulira beleženje in upravljanje komponent vozil ter spremljanje njihovih napak. 
Projekt omogoča dodajanje, iskanje, brisanje in shranjevanje podatkov o komponentah in napakah. 
Aplikacija uporablja sodobne pristope, kot so objektno usmerjeno programiranje, uporaba programskih vzorcev (Factory, Singleton, Strategy), 
asinhrono programiranje ter delo s strukturami List in Dictionary za hitro obdelavo podatkov.


STRUKTURA PROJEKTA:

    Abstraktni razredi:

    KomponentaVozila -> Motor -> Zavore -> ElektronskaEnota -> Kolesa

    NapakaVozila -> KriticnaNapaka -> ManjsaNapaka


    Glavni razredi:

    Program.cs (uporabniški meni in logika)

    KomponentaFactory (ustvarjanje komponent glede na izbrani tip)

    UrejanjePodatkov (shrani/prebere iz datotek)

    UpravljanjeDictionary (delo z dictionary za hitrejši dostop)

    Vmesniki (vsebuje vse potrebne vmesnike v enem razredu)

    AnalizatorNapak (analiza napak prek strategije) -> PodrobnaAnalizaStrategija -> StandardnaAnalizaStrategija ->



UPORABLJENI PROGRAMSKI VZORCI:

Factory vzorec – KomponentaFactory:

    Ustvarja objekte glede na izbran tip komponente.

    Logika za validacijo vhodnih podatkov in ustvarjanje je znotraj metode UstvariKomponento().

   

Singleton vzorec – UrejanjePodatkov:

    Zagotavlja enotno točko za delo z datotekami.

    Uporablja se za asinhrono shranjevanje in branje komponent in napak.

    Do instance dostopamo z UrejanjePodatkov.Instanca.

Strategy vzorec – AnalizatorNapak:

    Omogoča zamenjavo strategije za analizo napak med izvajanjem.

Strategije :

        StandardnaAnalizaStrategija (izpiše samo kritične napake)

        PodrobnaAnalizaStrategija (izpiše vse napake)

    Strategijo določa uporabnik preko menija v Program.cs.

PODATKOVNE STRUKTURE:

Dictionary:

    Uporabljeni sta dve strukturi slovarjev: -> Dictionary<string, KomponentaVozila> -> Dictionary<string, NapakaVozila>

    Omogočata hitro iskanje po serijski številki ali kodi napake.

    Uporabljata se v razredu UpravljanjeDictionary.

    Vsebuje tudi metode za dodajanje, iskanje, brisanje, prikaz in pretvorbo v seznam (List).

List:

    Seznami komponent in napak se uporabljajo pri shranjevanju in obdelavi.

    Vrnjeni iz dictionaryja za potrebe shranjevanja ali LINQ operacij.

ASINHRONO IN PARALELNO PROGRAMIRANJE:

Asinhrone metode:

    Branje in zapis v datoteke je izvedeno prek async/await.

    ShraniKomponenteAsync in PreberiKomponenteAsync

    ShraniNapakeAsync in PreberiNapakeAsync

    Izvedba se dogaja v ločenih nitih s pomočjo Task.Run, kar ne blokira uporabniškega vmesnika.

Parallel.ForEach:

    Uporablja se pri branju datotek in analizi napak.

    Zagotavlja hitrejšo obdelavo večjih seznamov (npr. več sto napak hkrati).

    Implementirano v UrejanjePodatkov 

SHRANJEVANJE V DATOTEKO:

    Komponente in napake se zapisujejo v komponente.txt in napake.txt.

    Vsaka vrstica predstavlja eno komponento ali napako v strukturirani obliki.

    Format je usklajen z metodami PridobiShranljiviString v posameznih razredih.

DODATNE FUNKCIONALNOSTI:

    Brisanje posamezne komponente ali napake po ID (ključu)

    Brisanje samo iz slovarja (hitro) ali iz datoteke (trajna odstranitev)

    Preverjanje praznosti slovarja

    Napredno validiranje vhodnih podatkov v meniju (tudi za prazne vnose)

    Ob začetku se samodejno naložijo podatki iz datotek in shranijo v slovar

ZAKLJUČEK: Projekt je modularno zasnovan, razširljiv in sledi načelom dobre prakse objektnega programiranja. 
rimeren je za nadaljnji razvoj z npr. povezavo na podatkovno bazo