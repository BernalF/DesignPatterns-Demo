# SOLID Principles & Design Patterns in C# 🎯

> **A comprehensive study of object-oriented design principles and practical design patterns through executable, gambling-platform examples.**

This C# solution demonstrates **both SOLID principles AND widely-used design patterns** through interactive console presentations and runnable projects. Each concept is isolated in its own project for maximum clarity and hands-on learning.

- **5 SOLID Principles** with dedicated projects and live examples
- **7 Design Patterns** with real-world implementations
- **Interactive Presentation** with color-coded, presenter-friendly slides
- **Gambling Platform Context** - All examples use a unified, realistic domain

The solution entry point is `StudyPresentation`, which offers separate tracks for studying SOLID principles and design patterns.

## 📋 Table of Contents

- [Requirements](#requirements)
- [What Is SOLID?](#what-is-solid)
  - [S - Single Responsibility Principle (SRP)](#s---single-responsibility-principle-srp)
  - [O - Open/Closed Principle (OCP)](#o---openclosed-principle-ocp)
  - [L - Liskov Substitution Principle (LSP)](#l---liskov-substitution-principle-lsp)
  - [I - Interface Segregation Principle (ISP)](#i---interface-segregation-principle-isp)
  - [D - Dependency Inversion Principle (DIP)](#d---dependency-inversion-principle-dip)
- [What Are Design Patterns?](#what-are-design-patterns)
- [The Relationship: SOLID ↔ Design Patterns](#the-relationship-solid--design-patterns)
- [SOLID Projects](#-solid-projects)
- [Design Patterns](#-design-patterns)
  - [Pattern Definitions](#pattern-definitions)
- [Interactive Presentation](#-interactive-presentation)
- [Quick Start](#-quick-start)
  - [Run the Presentation](#run-the-presentation)
  - [Run Individual Examples](#run-individual-examples)
  - [Build the Solution](#build-the-solution)
- [Project Structure](#-project-structure)
- [Learning Path](#-learning-path)
- [Key Concept: Liskov Substitution](#-deep-dive-liskov-substitution-in-plain-terms)

---

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

---

## What Are Design Patterns?

Design patterns are **proven, reusable solutions** to common design problems. While SOLID principles guide *how to structure* your code, design patterns guide *how to organize and interact* with those structures.

Design patterns address practical challenges like:
- **Object creation** (Factory Pattern)
- **Adding behavior dynamically** (Decorator Pattern)
- **Selecting algorithms at runtime** (Strategy Pattern)
- **Representing operations as objects** (Command Pattern)
- **Separating concerns** (CQRS Pattern)

Design patterns are **complementary to SOLID** — they help you apply SOLID principles in real-world scenarios. A well-chosen pattern often naturally enforces SOLID compliance.

---

## 🎓 SOLID Projects

| Project | Principle | Example |
| --- | --- | --- |
| `SingleResponsability` | SRP | `BetSlipRepository` retrieves bet slips and `CsvExporter` generates the CSV file. |
| `OpenClosePrinciple` | OCP | Commission calculation works with the `PlayerTier` abstraction, so new player tiers (VIP, Regular, HighRoller) can be added without changing the processing loop. |
| `LiskovSubstitution` | LSP | Only accounts that can truly withdraw implement `IWithdrawableAccount`. A restricted player account does not make that false promise. |
| `InterfaceSegregation` | ISP | Slot machines and sports betting terminals use focused interfaces: `ISlotMachine` and `ISportsBettingTerminal`. |
| `DependencyInversion` | DIP | `PlayerNotificationService` depends on `INotificationChannel`, allowing the delivery channel (email, SMS, push) to change independently. |
| `StudyPresentation` | Interactive presentation | Presents all five SOLID examples in one console session. |

---

## 🏗️ Design Patterns

The following patterns complement SOLID. They are practical techniques for organizing object creation, behavior, integrations, and application workflows.

| Project | Pattern | Example |
| --- | --- | --- |
| `StrategyPattern` | Strategy | `BettingService` receives an odds calculation strategy that can be replaced without changing betting logic. |
| `FactoryPattern` | Factory | `NotificationSenderFactory` creates an email or push notification sender from the selected channel. |
| `AdapterPattern` | Adapter | `LegacyPaymentAdapter` makes a legacy payment provider usable as `IWithdrawalProcessor`. |
| `DecoratorPattern` | Decorator | `CachedPlayerRepository` adds caching to `IPlayerRepository` without changing the repository. |
| `CommandPattern` | Command | `PlaceBetCommand` represents a betting action as an object. |
| `ResultPattern` | Result Pattern | `WithdrawalService` returns success or validation failure as `Result<T>`. |
| `CqrsPattern` | CQRS | Separate handlers create a bet with a command and read it with a query. |
| `StudyPresentation` | Interactive presentation | Also presents the seven pattern examples in one console session. |

### Pattern Definitions

#### Strategy Pattern

**Human explanation:** Allow the user to choose from different ways of doing the same task, without hardcoding the choice into your code.

**Software explanation:** Define a family of algorithms, encapsulate each one, and make them interchangeable. The strategy lets the algorithm vary independently from the clients that use it.

#### Factory Pattern

**Human explanation:** Avoid asking "which concrete class do I need?" by delegating object creation to a specialized factory.

**Software explanation:** Provide an interface for creating objects, but let subclasses or a factory method decide which class to instantiate. This decouples the client from concrete constructors and centralizes creation logic.

#### Adapter Pattern

**Human explanation:** Use a third-party tool or legacy system by wrapping it so it fits the interface your code expects.

**Software explanation:** Convert the interface of a class into another interface that clients expect. An adapter lets classes work together that could not otherwise because of incompatible interfaces.

#### Decorator Pattern

**Human explanation:** Add new features to an object (like caching or logging) without modifying its original code or breaking other uses of it.

**Software explanation:** Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality while preserving the original contract.

#### Command Pattern

**Human explanation:** Turn a user request or action into an object that can be stored, queued, undone, logged, or executed later.

**Software explanation:** Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.

#### Result Pattern

**Human explanation:** Instead of throwing exceptions or returning null for failures, return an object that explicitly says whether the operation succeeded or failed and why.

**Software explanation:** Represent the outcome of an operation as a value that can be either success (with a result) or failure (with an error). This makes error handling explicit and composable.

#### CQRS (Command Query Responsibility Segregation)

**Human explanation:** Split your code that modifies data from your code that reads data. Different paths, different optimizations, easier to scale each independently.

**Software explanation:** Separate the model that updates information from the model that reads information. This pattern, especially useful in complex domains, lets read and write sides evolve independently and optimize for their distinct concerns.

---

## The Relationship: SOLID ↔ Design Patterns

| Aspect | SOLID Principles | Design Patterns |
|--------|------------------|-----------------|
| **What are they?** | Guidelines for code structure | Proven solutions to design problems |
| **Focus** | How to organize responsibilities | How to organize interactions |
| **Scope** | Class/module level | System/architecture level |
| **Example** | "Keep interfaces small" (ISP) | "Use Factory to centralize creation" |
| **Benefit** | Code easier to understand & maintain | Code easier to extend & reuse |

**In this project:** Each design pattern example is intentionally built to demonstrate how applying it naturally helps achieve SOLID principles.

---

## 🎬 Interactive Presentation

`StudyPresentation` is designed for explaining the concepts to an audience. The main menu lets you choose the SOLID or design-patterns track. Each slide contains:

1. The principle name and definition.
2. The key design decision used in the example.
3. A focused code excerpt.
4. A live result from the actual example project.

The application waits for a key press between each stage, so the presenter can explain the concept before advancing. Sections use different console colors to distinguish definitions, applied design decisions, code, bad designs, and results.

The Liskov slide also includes a red, display-only bad-design example. It shows a `RestrictedPlayerAccount` falsely implementing `IWithdrawableAccount` and throwing at runtime. The correct version avoids the error by implementing only the smaller contract that it can honor.

---

## ⚡ Quick Start

### Run the Presentation

Open `DesignPatternsDemo.sln` in Visual Studio, set `StudyPresentation` as the startup project, then run it. Select `1` for SOLID or `2` for design patterns.

From a terminal in the solution root:

```powershell
dotnet run --project .\StudyPresentation\StudyPresentation.csproj
```

Use any key to advance through the presentation.

### Run Individual Examples

Each principle and pattern project can be run by itself:

```powershell
dotnet run --project .\LiskovSubstitution\LiskovSubstitution.csproj
```

Replace `LiskovSubstitution` with any other project name to explore.

### Build the Solution

```powershell
dotnet build .\DesignPatternsDemo.sln
```

---

## 📁 Project Structure

```
DesignPatternsDemo.sln
├── SOLID Principles (5 projects)
│   ├── SingleResponsability/      # SRP: Separated concerns
│   ├── OpenClosePrinciple/        # OCP: Extended via abstraction
│   ├── LiskovSubstitution/        # LSP: Contract-respecting types
│   ├── InterfaceSegregation/      # ISP: Focused interfaces
│   └── DependencyInversion/       # DIP: Depend on abstractions
├── Design Patterns (7 projects)
│   ├── StrategyPattern/           # Interchangeable algorithms
│   ├── FactoryPattern/            # Centralized creation
│   ├── AdapterPattern/            # Interface compatibility
│   ├── DecoratorPattern/          # Dynamic behavior addition
│   ├── CommandPattern/            # Request encapsulation
│   ├── ResultPattern/             # Explicit success/failure
│   └── CqrsPattern/               # Separated read/write
└── StudyPresentation/             # Interactive presenter
```

---

## 🗺️ Learning Path

### Recommended Order

**For SOLID Beginners:**
1. Start with **SRP** (SingleResponsability) — Simplest to understand
2. Then **OCP** (OpenClosePrinciple) — Introduces abstraction
3. Then **LSP** (LiskovSubstitution) — Deepens contract understanding
4. Then **ISP** (InterfaceSegregation) — Refines interfaces
5. Finally **DIP** (DependencyInversion) — Ties everything together

**For Design Patterns Learners:**
1. Start with **Factory** — Simplest creation pattern
2. Then **Strategy** — Simplest behavioral pattern
3. Then **Decorator** — Structural pattern with clear purpose
4. Then **Adapter** — Real-world integration challenge
5. Then **Command** — Encapsulation pattern
6. Then **Result** — Error handling paradigm
7. Finally **CQRS** — Advanced architectural pattern

**Full Journey:** Use the interactive `StudyPresentation` to progress through all concepts in a guided, color-coded presentation.

---

## 💡 Deep Dive: Liskov Substitution in Plain Terms

An interface is a promise. When a type implements an interface, callers trust that every operation in that interface is supported.

`IWithdrawableAccount` promises that `Withdraw` works. `RegularPlayerAccount` can keep that promise. A restricted player account cannot allow withdrawals, so it must not implement `IWithdrawableAccount` and then throw an exception when `Withdraw` is called.

This is the key LSP rule:

> **A type must not claim to support behavior that it cannot safely provide.**

By using `IPlayerAccount` for common behavior and `IWithdrawableAccount` only for accounts that support withdrawals, invalid uses are prevented at compile time.
