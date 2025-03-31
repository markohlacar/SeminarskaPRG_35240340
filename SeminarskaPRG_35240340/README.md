# VoziloKomponenteApp

A C# project that simulates vehicle component management, error tracking, and analysis. The application uses object-oriented design principles, modern patterns like Factory, Singleton, and Strategy, and includes support for async programming and efficient data processing using `List` and `Dictionary`.

---

## 📦 Project Structure

### 🔧 Abstract Base Classes

- **KomponentaVozila** – Abstract base class for all vehicle components.
  - `Motor`
  - `Zavore`
  - `ElektronskaEnota`
  - `Kolesa`
  - `Rezervoar`

- **NapakaVozila** – Abstract base class for vehicle error types.
  - `KriticnaNapaka`
  - `ManjsaNapaka`

---

## 🧱 Design Patterns Used

### 🏭 Factory Pattern – `KomponentaFactory`
Used for creating vehicle components without directly instantiating each one.

**Purpose:**
> Simplifies object creation in the main logic (`Program.cs`). Components can be created dynamically using string identifiers.

---

### 🔁 Singleton Pattern – `UrejanjePodatkov`
Ensures only one instance is responsible for reading and writing data throughout the application.

**Usage in Code:**
```csharp
UrejanjePodatkov.Instanca
