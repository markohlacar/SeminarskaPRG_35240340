# Projekt: Sledenje komponent in napak na vozilih v proizvodnem podjetju.

Projekt v jeziku C#, ki simulira upravljanje komponent vozila, beleženje napak in njihovo analizo. Aplikacija uporablja objektno usmerjeno zasnovo, sodobne programske vzorce (Factory, Singleton, Strategy) ter podpira asinhrono programiranje in učinkovito obdelavo podatkov z uporabo struktur `List` in `Dictionary`.

---

## 📦 Struktura projekta

### 🔧 Abstraktni osnovni razredi

- **KomponentaVozila** – Abstraktni razred, iz katerega izhajajo vse komponente vozila:
  - `Motor`
  - `Zavore`
  - `ElektronskaEnota`
  - `Kolesa`
  

- **NapakaVozila** – Abstraktni razred za različne vrste napak:
  - `KriticnaNapaka`
  - `ManjsaNapaka`

---

## 🧱 Uporabljeni programski vzorci

### 🏭 Factory vzorec – `KomponentaFactory`
Uporablja se za ustvarjanje različnih komponent vozila brez neposrednega instanciranja.

**Namen:**
- Poenostavi ustvarjanje objektov v glavni metodi (`Program.cs`). Komponente se ustvarjajo dinamično glede na podano vrsto v obliki niza.
- Ustvarjanje objektov ob branju iz datoteke.

---

### 🔁 Singleton vzorec – `UrejanjePodatkov`
Zagotavlja, da obstaja samo ena instanca razreda za branje in shranjevanje podatkov v datoteke ali bazo.

**Uporaba v kodi:**
```csharp
UrejanjePodatkov.Instanca


### 🧠 **Strategy pattern** AnalizatorNapak

Omogoča izbiro različnih strategij za analizo napak.

Uporaba v:

Program.cs → IzvediAnalizoNapak()

Možne strategije:
- `StandardnaAnalizaStrategija()` – prikaže samo kritične napake.
- `PodrobnaAnalizaStrategija()` – prikaže vse napake.



💾 Podatkovne strukture

Aplikacija uporablja učinkovite strukture za shranjevanje in dostop do podatkov:

    List<T> – za shranjevanje seznamov podatkov:

        List<KomponentaVozila> → vsebuje vse komponente vozila.

        List<NapakaVozila> → vsebuje vse zabeležene napake.

    Dictionary<TKey, TValue> – za hiter dostop in iskanje podatkov:

        Uporablja se v UpravljanjeDictionary za iskanje komponent/napak po ID-ju ali kodi.

        Primer:

        Dictionary<string, KomponentaVozila>

⚙️ Asinhrono in paralelno programiranje
🔄 Asinhrone metode (async/await)

V razredu UrejanjePodatkov so implementirane asinhrone metode za:

    Branje in shranjevanje podatkov brez blokiranja glavne niti.

🚀 Paralelna obdelava – Parallel.ForEach

V AnalizatorNapak je uporabljena paralelna obdelava:

    Parallel.ForEach omogoča hkratno analizo več napak in pohitritev postopka.
