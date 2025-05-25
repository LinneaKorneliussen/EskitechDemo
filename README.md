# EskitechDemo API

EskitechDemo är ett projekt som visar hur man bygger en modern **ASP.NET Core Web API** för produkt- och lagerhantering. Projektet använder **.NET 8.0**, **Entity Framework Core** för databasåtkomst mot SQL Server LocalDB, **AutoMapper** för enkel objektmappning, och **Swagger** för smidig API-dokumentation och testning.

---

## Vad är EskitechDemo?

Det här projektet är skapat för att lära och demonstrera hur man kan bygga en RESTful Web API som hanterar produkter och deras lagerstatus.

- Skapa, läsa, uppdatera och ta bort produkter.
- Hantera lagerkvantiteter för varje produkt på olika lagerplatser.
- Lokal SQL Server LocalDB används som databas.
- Automatisk databas- och dataseedning vid första start.
- Inbyggd Swagger UI för enkel dokumentation och testning via webbläsaren.

---

## Teknologier och verktyg

- **ASP.NET Core 8.0 Web API**
- **Entity Framework Core 8.0** med SQL Server LocalDB
- **AutoMapper** för dataöverföringsobjekt (DTO)
- **Swagger (Swashbuckle)** för API-dokumentation och testning
- **Visual Studio 2022** eller **Visual Studio Code**

---

## Förutsättningar

Innan du startar, säkerställ att du har:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server LocalDB (ingår vanligtvis i Visual Studio, kan installeras separat)
- Visual Studio 2022 eller Visual Studio Code med C#-tillägg

---

## Kom igång

1. Klona repot:

   ```bash
   git clone https://github.com/ditt-användarnamn/eskitechdemo.git