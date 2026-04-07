# 🚀 AlphaFleet

A fleet management web application for organizing, browsing, and commanding starships across multiple factions. Built with ASP.NET Core MVC and Entity Framework Core, following a multi-project layered architecture.

## 📋 Features

- **Ship Management** — Full CRUD (Create, Read, Update, Delete) for starships
- **Combat Stats** — Every ship has Attack, Defense, and Health values calculated automatically from its hull class and rarity
- **Fleet Browsing** — View all fleets and their assigned ships; each user account owns exactly one fleet
- **Gacha Rarity System** — Interactive dice-roll button that assigns ship rarity (Common, Rare, Epic, Legendary) with weighted probabilities
- **Faction System** — Choose your allegiance: **Earthlings** or **Martians**
- **Station Network** — Space stations with their own tiered combat stats
- **Admiral Profiles** — Fleet admirals with ranks and bios
- **Search** — Filter ships by name or class
- **Authentication** — ASP.NET Core Identity with login/register (all pages require authorization)
- **Dark Theme** — Bootstrap 5.3 dark mode UI
- **Seed Data** — Pre-loaded ships (one per hull class), fleets, admirals, and stations

## 🏗️ Architecture

The solution follows a **multi-project layered architecture** with clear separation of concerns:

```
AlphaFleet.slnx
│
├── AlphaFleet/                  # Web layer (Controllers, Views, Program.cs)
├── AlphaFleet.Services/         # Business logic layer (Service interfaces + implementations)
├── AlphaFleet.ViewModels/       # View models for form binding
├── AlphaFleet.Data/             # Data access layer (DbContext, EF configurations, migrations)
├── AlphaFleet.Data.Models/      # Entity models and enums
└── AlphaFleet.Common/           # Shared constants (validation rules)
```

**Dependency graph:**
```
Web → Services → Data → Data.Models
 ↘    ↘                    ↗
  ViewModels → Common ────┘
```

### Key Patterns
- **Service Layer** — Controllers depend on interfaces (`IShipService`, `IFleetService`, `IGachaService`), not on `DbContext`
- **Dependency Injection** — All services registered as scoped with interface-to-implementation mapping
- **Async EF Core** — All database operations use `async/await` (`ToListAsync`, `SaveChangesAsync`, etc.)
- **Entity Configurations** — `IEntityTypeConfiguration<T>` with `HasData` seeding
- **Stats Helper** — `ShipStatsHelper` calculates Attack/Defense/Health from hull class and rarity at creation/update time

## 🛠️ Tech Stack

| Technology | Version |
|------------|---------|
| .NET | 10 |
| C# | 14.0 |
| ASP.NET Core MVC | 10.0 |
| Entity Framework Core | 10.0.5 |
| ASP.NET Core Identity | 10.0.5 |
| SQL Server (LocalDB) | — |
| Bootstrap | 5.3+ (dark theme) |

## 📦 Entity Models

### Ship
`Id` · `Name` · `Class` · `ShipHullClass` (enum) · `Rarity` (enum) · `Attack` · `Defense` · `Health` · `ShipProductionYear` · `ImageUrl` · `History` · `FleetId` (FK) · `IsAvailable`

### Fleet
`Id` · `Name` · `Location` · `UserId` (FK → ApplicationUser, 1-to-1) · `Ships` (collection) · `Admiral` (1-to-1)

### Station
`Id` · `Name` · `Location` · `Description` · `Attack` · `Defense` · `Health` · `ImageUrl` · `IsDestroyed`

### Admiral
`Id` · `FirstName` · `LastName` · `Rank` (enum) · `Bio` · `ImageUrl` · `FleetId` (FK, 1-to-1)

### ApplicationUser *(extends IdentityUser)*
`Faction` (enum)

### Enums
- **ShipRarity** — Common, Rare, Epic, Legendary
- **ShipHullClass** — Fighter, Interceptor, Corvette, Frigate, Destroyer, Cruiser, HeavyCruiser, Battlecruiser, CapitalShip, AircraftCarrier
- **Faction** — None, Earthlings, Martians
- **AdmiralRank** — RearAdmiral, ViceAdmiral, Admiral, FleetAdmiral, GrandAdmiral

## ⚔️ Combat Stats System

Ship stats are auto-calculated by `ShipStatsHelper` — no manual input required.

**Base stats per hull class** (each tier is ×2 the previous):

| Hull Class | Attack | Defense | Health |
|---|---|---|---|
| Fighter | 10 | 1 | 50 |
| Interceptor | 20 | 2 | 100 |
| Corvette | 40 | 4 | 200 |
| Frigate | 80 | 8 | 400 |
| Destroyer | 160 | 16 | 800 |
| Cruiser | 320 | 32 | 1,600 |
| HeavyCruiser | 640 | 64 | 3,200 |
| Battlecruiser | 1,280 | 128 | 6,400 |
| CapitalShip | 2,560 | 256 | 12,800 |
| AircraftCarrier | 5,120 | 512 | 25,600 |

**Rarity multipliers** (applied on top of base stats):

| Rarity | Multiplier |
|---|---|
| Common | ×1.10 |
| Rare | ×1.20 |
| Epic | ×1.40 |
| Legendary | ×1.80 |

## 🚀 Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server LocalDB (included with Visual Studio)

### Setup

	1. Clone the repository:

2. Apply database migrations:

3. Run the application:

4. Open `https://localhost:5001` in your browser, register an account, choose your faction, and start commanding your fleet!

## 📁 Project Structure

| Project | Responsibility |
|---------|---------------|
| `AlphaFleet` | ASP.NET Core Web — Controllers, Views, Razor pages, static assets, `Program.cs` |
| `AlphaFleet.Services` | Service interfaces and implementations — business logic, async DB queries, `ShipStatsHelper` |
| `AlphaFleet.ViewModels` | View models for form binding and validation |
| `AlphaFleet.Data` | `ApplicationDbContext`, EF Core configurations, migrations |
| `AlphaFleet.Data.Models` | Entity classes (`Ship`, `Fleet`, `Station`, `Admiral`, `ApplicationUser`) and enums |
| `AlphaFleet.Common` | Shared validation constants (`EntityValidation`) |
