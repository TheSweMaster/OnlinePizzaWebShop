# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run Commands

```bash
# Build
dotnet build

# Run (launches at https://localhost:7241 or http://localhost:58756)
dotnet run --project OnlinePizzaWebApplication
```

There is no test project. The solution has no unit/integration test setup.

## Architecture

ASP.NET Core 10.0 MVC e-commerce application (online pizza shop) using Razor Views, Entity Framework Core 10 with SQL Server LocalDB, and ASP.NET Core Identity for authentication. Uses the minimal hosting model (top-level `Program.cs`, no `Startup.cs`).

### Layered Structure

- **Controllers/** — 11 controllers handling public browsing, shopping cart, checkout, user auth, and admin CRUD operations. Admin endpoints use `[Authorize(Roles = "Admin")]`.
- **Repositories/** — Repository pattern for data access. Each entity has an interface + implementation (e.g., `IPizzaRepository`/`PizzaRepository`). Registered as transient in DI except `ShoppingCart` (scoped).
- **Models/** — Domain entities with DataAnnotations validation. Key entities: `Pizzas`, `Categories`, `Ingredients`, `PizzaIngredients` (join table), `Reviews`, `Order`, `OrderDetail`, `ShoppingCart`, `ShoppingCartItem`.
- **ViewModels/** — `LoginViewModel`, `RegisterViewModel`, `SearchPizzasViewModel`, `ShoppingCartViewModel`.
- **Views/Components/** — `ShoppingCartSummary`, `CarouselMenu`, `CategoryMenu` view components.
- **Data/** — `AppDbContext` (inherits `IdentityDbContext<IdentityUser>`), `DbInitializer` seeds sample data and creates an Admin user (admin/Password123).

### Key Patterns

- **Shopping cart** is session-based (stored in DB via `ShoppingCartItems` table, keyed by session GUID). Injected as a scoped service via `ShoppingCart.GetCart(IServiceProvider)`.
- **Entity relationships**: Pizza→Category (many-to-one), Pizza↔Ingredients (many-to-many via `PizzaIngredients`), Pizza→Reviews (one-to-many), Order→OrderDetails (one-to-many).
- **Pipeline order** (Program.cs): exception handling → HTTPS redirect → routing → session → authentication → authorization → static assets → endpoints.

### Configuration

- **Database**: SQL Server LocalDB, connection string in `appsettings.json` (database name: `PizzaShop`).
- **Identity**: min 8-char password, requires digit + uppercase, lockout after 10 failed attempts (30 min).
- **Session**: 30-minute idle timeout, HTTP-only cookies.
