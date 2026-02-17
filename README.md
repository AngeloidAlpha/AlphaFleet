# 🚀 AlphaFleet

A fleet management web application for organizing, browsing, and exploring starships across multiple fleets. Built with ASP.NET Core MVC and Entity Framework Core, following a multi-project layered architecture.

## 📋 Features

- **Ship Management** — Full CRUD (Create, Read, Update, Delete) for starships
- **Fleet Browsing** — View all fleets and their assigned ships
- **Gacha Rarity System** — Interactive dice-roll button that assigns ship rarity (Common, Rare, Epic, Legendary) with weighted probabilities
- **Admiral Profiles** — Fleet admirals with ranks and bios
- **Search** — Filter ships by name or class
- **Authentication** — ASP.NET Core Identity with login/register (all pages require authorization)
- **Dark Theme** — Bootstrap 5.3 dark mode UI
- **Seed Data** — Pre-loaded ships, fleets, and admirals

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

## 🛠️ Tech Stack

| Technology | Version |
|------------|---------|
| .NET | 10 |
| C# | 14.0 |
| ASP.NET Core MVC | 10.0 |
| Entity Framework Core | 10.0.3 |
| ASP.NET Core Identity | 10.0.3 |
| SQL Server (LocalDB) | — |
| Bootstrap | 5.3+ (dark theme) |

## 📦 Entity Models

### Ship
`Id` · `Name` · `Class` · `ShipHullClass` (enum) · `Rarity` (enum) · `ShipProductionYear` · `ImageUrl` · `History` · `FleetId` (FK) · `IsAvailable`

### Fleet
`Id` · `Name` · `Location` · `Ships` (collection) · `Admiral` (1-to-1)

### Admiral
`Id` · `FirstName` · `LastName` · `Rank` (enum) · `Bio` · `ImageUrl` · `FleetId` (FK, 1-to-1)

### Enums
- **ShipRarity** — Common, Rare, Epic, Legendary
- **ShipHullClass** — Fighter, Corvette, Frigate, Destroyer, HeavyCruiser, Battleship, CapitalShip, Carrier, Dreadnought, AircraftCarrier
- **AdmiralRank** — RearAdmiral, ViceAdmiral, Admiral, FleetAdmiral, GrandAdmiral

## 🚀 Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server LocalDB (included with Visual Studio)

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/AngeloidAlpha/AlphaFleet.git
   cd AlphaFleet
   ```

2. Apply database migrations:
   ```bash
   dotnet ef database update --startup-project AlphaFleet --project AlphaFleet.Data
   ```

3. Run the application:
   ```bash
   dotnet run --project AlphaFleet
   ```

4. Open `https://localhost:5001` in your browser, register an account, and start managing your fleet!

## 📁 Project Structure

| Project | Responsibility |
|---------|---------------|
| `AlphaFleet` | ASP.NET Core Web — Controllers, Views, Razor pages, static assets, `Program.cs` |
| `AlphaFleet.Services` | Service interfaces and implementations — business logic, async DB queries |
| `AlphaFleet.ViewModels` | View models for form binding and validation |
| `AlphaFleet.Data` | `ApplicationDbContext`, EF Core configurations, migrations |
| `AlphaFleet.Data.Models` | Entity classes (`Ship`, `Fleet`, `Admiral`) and enums |
| `AlphaFleet.Common` | Shared validation constants (`EntityValidation`) |
