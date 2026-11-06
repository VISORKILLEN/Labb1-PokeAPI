# Labb1-PokeAPI

En ASP.NET Core MVC-applikation som hämtar Pokémon-information från [PokéAPI](https://pokeapi.co/). Bläddra bland Pokémon, sök efter en Pokémon med namn eller ID och visa detaljer som hämtas direkt från API:et.

## Funktioner

- Visar Pokémon i en paginerad lista.
- Sök efter Pokémon med namn eller ID.
- Visar detaljer för vald Pokémon.
- Hanterar fel, till exempel när Pokémon inte hittas eller PokéAPI inte är tillgängligt.
- Byggd med ASP.NET Core MVC och C#.

## Kom igång

### Förutsättningar

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Internetanslutning för att nå PokéAPI

### Kör lokalt

Klona repot och gå till projektmappen:

```bash
git clone https://github.com/VISORKILLEN/Labb1-PokeAPI.git
cd Labb1-PokeAPI/Labb1-PokeAPI
```

Starta applikationen:

```bash
dotnet run
```

Öppna sedan adressen som visas i terminalen. Applikationen använder PokéAPI:s v2-endpoint: `https://pokeapi.co/api/v2/`.

## Projektstruktur

- `Controllers/` – hanterar sidornas förfrågningar och navigering.
- `Services/` – kommunicerar med PokéAPI.
- `Models/` – modeller för Pokémon-data från API:et.
- `Views/` – Razor-vyer för listan, sökresultat och Pokémon-detaljer.
- `Middlewares/` – hantering av fel i HTTP-förfrågningar.

## Teknik

- C#
- ASP.NET Core MVC (.NET 10)
- Razor, HTML och CSS
- PokéAPI

## Om projektet

Det här är en skoluppgift (labb) med fokus på att använda ett externt REST-API i en ASP.NET Core MVC-applikation.

## Licens

Ingen licens har angetts ännu.
