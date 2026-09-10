# SOLID Principles in C#

A small C# solution for studying SOLID principles and widely used design patterns through executable examples.

The solution contains one project per concept and one interactive console presentation. `StudyPresentation` is the central entry point for choosing the SOLID or design-patterns study track.

## Requirements

- .NET SDK 10.0 or later
- Visual Studio 2026 or later, or Visual Studio Code with the C# Dev Kit

## What Is SOLID?

SOLID is a set of object-oriented design guidelines. They help developers write code that is easier to understand, extend, test, and maintain.

The following software definitions are concise paraphrases of the principles popularized by Robert C. Martin. They complement the human explanations used in this project.

### S - Single Responsibility Principle (SRP)

**Human explanation:** Give each class one clear job. A class that retrieves data should not also format files, send emails, and calculate prices.

**Software explanation:** A module should have one responsibility, which means it should be accountable to one group of users or stakeholders and have one primary reason to change.

### O - Open/Closed Principle (OCP)

**Human explanation:** Add new behavior without repeatedly editing code that already works.

**Software explanation:** Design modules so their behavior can be extended, usually through polymorphism or composition, while existing, tested source code remains unchanged.

### L - Liskov Substitution Principle (LSP)

**Human explanation:** Do not claim an object can do something when it cannot. If code expects a type to perform an operation, every implementation must perform it correctly.

**Software explanation:** Any implementation used through a base type or interface must preserve that abstraction's observable behavior, including its valid inputs, results, invariants, and error expectations.

### I - Interface Segregation Principle (ISP)

**Human explanation:** Do not make a class carry methods it does not need. Keep its contracts small and relevant.

**Software explanation:** Client code should depend on small, cohesive interfaces tailored to its needs instead of broad interfaces that force implementations to provide unused operations.

### D - Dependency Inversion Principle (DIP)

**Human explanation:** Important business logic should not be tightly tied to a particular database, email provider, or framework.

**Software explanation:** High-level policy and low-level implementation should both depend on abstractions. Details implement those abstractions, allowing the direction of dependency to be inverted.

## Projects

| Project | Principle | Example |
| --- | --- | --- |
| `SingleResponsability` | SRP | `StudentRepository` retrieves students and `CsvExporter` generates the CSV file. |
| `OpenClosePrinciple` | OCP | Salary calculation works with the `Employee` abstraction, so new employee types can be added without changing the processing loop. |
| `LiskovSubstitution` | LSP | Only accounts that can truly withdraw implement `IWithdrawableAccount`. A fixed-term account does not make that false promise. |
| `InterfaceSegregation` | ISP | Printing and scanning use focused interfaces: `IPrinter` and `IScanner`. |
| `DependencyInversion` | DIP | `NotificationService` depends on `IMessageSender`, allowing the delivery channel to change independently. |
| `StudyPresentation` | Interactive presentation | Presents all five SOLID examples in one console session. |

## Design Patterns

The following patterns complement SOLID. They are practical techniques for organizing object creation, behavior, integrations, and application workflows.

| Project | Pattern | Example |
| --- | --- | --- |
| `StrategyPattern` | Strategy | `CheckoutService` receives a discount algorithm that can be replaced without changing checkout logic. |
| `FactoryPattern` | Factory | `MessageSenderFactory` creates an email or SMS sender from the selected channel. |
| `AdapterPattern` | Adapter | `LegacyPaymentAdapter` makes a legacy payment provider usable as `IPaymentGateway`. |
| `DecoratorPattern` | Decorator | `CachedProductCatalog` adds caching to `IProductCatalog` without changing the catalog. |
| `CommandPattern` | Command | `SendWelcomeEmailCommand` represents an email action as an object. |
| `ResultPattern` | Result Pattern | `RegistrationService` returns success or validation failure as `Result<T>`. |
| `CqrsPattern` | CQRS | Separate handlers create an order with a command and read it with a query. |
| `StudyPresentation` | Interactive presentation | Also presents the seven pattern examples in one console session. |

### Pattern Definitions

- **Strategy:** Encapsulates interchangeable algorithms behind a shared interface.
- **Factory:** Centralizes object creation so callers do not depend on concrete constructors.
- **Adapter:** Converts one interface into another interface expected by the client.
- **Decorator:** Wraps an object to add behavior while preserving the original contract.
- **Command:** Encapsulates a request as an object so it can be executed, queued, logged, or retried.
- **Result Pattern:** Models expected success or failure explicitly as a returned value.
- **CQRS:** Separates commands that change state from queries that read state.

## The Interactive Presentation

`StudyPresentation` is designed for explaining the concepts to an audience. The main menu lets you choose the SOLID or design-patterns track. Each slide contains:

1. The principle name and definition.
2. The key design decision used in the example.
3. A focused code excerpt.
4. A live result from the actual example project.

The application waits for a key press between each stage, so the presenter can explain the concept before advancing. Sections use different console colors to distinguish definitions, applied design decisions, code, bad designs, and results.

The Liskov slide also includes a red, display-only bad-design example. It shows a `FixedTermAccount` falsely implementing `IWithdrawableAccount` and throwing at runtime. The correct version avoids the error by implementing only the smaller contract that it can honor.

## Start From the Menu

Open `SOLID.sln` in Visual Studio, set `StudyPresentation` as the startup project, then run it. Select `1` for SOLID or `2` for design patterns.

From a terminal in the solution root:

```powershell
dotnet run --project .\StudyPresentation\StudyPresentation.csproj
```

## Run the Presentation

The menu is the recommended presentation entry point. To run the unified host directly from a terminal:

From a terminal in the solution root:

```powershell
dotnet run --project .\StudyPresentation\StudyPresentation.csproj
```

Use any key to advance through the presentation.

## Run an Individual Example

Each principle project can also be run by itself:

```powershell
dotnet run --project .\LiskovSubstitution\LiskovSubstitution.csproj
```

Replace `LiskovSubstitution` with the project you want to explore.

## Build the Solution

```powershell
dotnet build .\SOLID.sln
```

## Liskov Substitution in Plain Terms

An interface is a promise. When a type implements an interface, callers trust that every operation in that interface is supported.

`IWithdrawableAccount` promises that `Withdraw` works. `SavingsAccount` can keep that promise. A fixed-term account cannot allow withdrawals, so it must not implement `IWithdrawableAccount` and then throw an exception when `Withdraw` is called.

This is the key LSP rule:

> A type must not claim to support behavior that it cannot safely provide.

By using `IAccount` for common behavior and `IWithdrawableAccount` only for accounts that support withdrawals, invalid uses are prevented at compile time.
