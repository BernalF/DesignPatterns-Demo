# AI Agent Guidelines for SOLID Principles & Design Patterns Study Project

## Project Overview

This is an **educational C# solution** that demonstrates **both SOLID principles AND modern design patterns** through **executable, focused examples**. Each principle or pattern is isolated in its own project to maximize clarity and learning value.

- **Target Audience**: Developers learning SOLID principles and design patterns
- **Domain Context**: Gambling platform (unified domain across all examples)
- **Delivery Model**: Interactive console presentation (StudyPresentation) + individual runnable projects
- **Tech Stack**: .NET 10.0, C# 13+ with modern features (top-level statements, primary constructors, sealed types)
- **Entry Point**: `StudyPresentation` project (main menu for SOLID or patterns track)

## Project Structure

### SOLID Principles (5 projects)
- **SingleResponsability**: Each class has one job → BetSlipRepository (data) + CsvExporter (export)
- **OpenClosePrinciple**: Extend without editing → New player tiers via `PlayerTier` abstraction (RegularPlayer, VipPlayer)
- **LiskovSubstitution**: Contract-respecting subtypes → Only withdrawable accounts implement `IWithdrawableAccount` (RegularPlayerAccount vs RestrictedPlayerAccount)
- **InterfaceSegregation**: Small, focused contracts → `ISlotMachine` and `ISportsBettingTerminal` instead of multi-method device interface
- **DependencyInversion**: Abstract dependencies → `PlayerNotificationService` depends on `INotificationChannel`, not concrete channels

### Design Patterns (7 projects)
- **StrategyPattern**: Interchangeable algorithms (`IOddsCalculationStrategy` - FixedOdds vs DynamicOdds)
- **FactoryPattern**: Centralized object creation (`NotificationSenderFactory`)
- **AdapterPattern**: Interface conversion (`LegacyPaymentAdapter` → `IWithdrawalProcessor`)
- **DecoratorPattern**: Add behavior transparently (`CachedPlayerRepository` wraps `IPlayerRepository`)
- **CommandPattern**: Requests as objects (`PlaceBetCommand`)
- **ResultPattern**: Explicit success/failure (`Result<T>` for withdrawal validation)
- **CqrsPattern**: Separate read/write (CreateBetHandler / GetBetHistoryHandler)

### Presentation (1 project)
- **StudyPresentation**: Main console entry point (menu-driven, color-coded slides, keystroke navigation for both SOLID and patterns)

See [README.md](README.md) for detailed principle definitions and pattern examples.

## Code Conventions

### Consistent Across All Projects
- **Namespace**: Matches project directory name exactly (e.g., `namespace SingleResponsibility;`)
- **Demo Class**: Public static `PrincipleDemo` or `PatternDemo` with public static `Run()` method
- **Entry Point**: Minimal `Program.cs` that calls `PrincipleDemo.Run()` or `PatternDemo.Run()`
- **Scope**: Implementation types marked `internal` or `sealed` to emphasize the public contract

### Modern C# Features Used
- **Top-level statements** in Program.cs
- **Primary constructors** (e.g., `class CheckoutService(IDiscountStrategy discount) { }`)
- **Sealed types** to prevent accidental inheritance
- **Implicit usings** enabled (`ImplicitUsings`)
- **Nullable reference types** enabled (`Nullable`)
- **Record types** for value semantics where appropriate
- **XML documentation** comments on public members

### Project File Configuration
```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
  <TargetFramework>net10.0</TargetFramework>
  <RootNamespace>{ProjectName}</RootNamespace>
  <ImplicitUsings>enable</ImplicitUsings>
  <Nullable>enable</Nullable>
</PropertyGroup>
```

### Program.cs Template (Required Pattern)
**Every principle and pattern project must follow this exact structure:**
```csharp
namespace YourProjectName;

/// <summary>Runs the [Principle/Pattern] console demonstration.</summary>
public static class PrincipleDemo  // or PatternDemo
{
    /// <summary>One-line description of what the demo shows.</summary>
    public static void Run()
    {
        // Implementation: ~10-20 lines max
        // Should show setup and observable output via Console.WriteLine
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when this project is executed directly.</summary>
    private static void Main()
    {
        PrincipleDemo.Run();  // or PatternDemo.Run()
    }
}
```
**Critical rules:**
- Namespace must match the project folder name exactly
- Public static `Run()` method is the entry point for StudyPresentation
- Implementation in `Run()` should be concise and fit on a presentation slide
- All helper types should be `internal` or `sealed` (not exported to studyPresentation)

## Build & Run Commands

**Build solution:**
```bash
dotnet build DesignPatternsDemo.sln
```

**Run StudyPresentation (interactive menu):**
```bash
cd StudyPresentation
dotnet run
```

**Run a specific principle/pattern project:**
```bash
cd SingleResponsability
dotnet run
```

**Build and run a specific project:**
```bash
dotnet run --project .\StrategyPattern\
```

## Adding New Examples

When extending this project (e.g., adding another pattern or a SOLID antipattern example), follow this **integration checklist** in order:

### Step 1: Create the Core Project
1. **Create a new project directory** with the concept name (e.g., `PrototypePattern/`)
2. **Add .csproj** with standard settings (copy from any existing principle/pattern project and change `RootNamespace`)
3. **Create namespace** matching directory name exactly
4. **Implement** `PatternDemo` or `PrincipleDemo` class with public `Run()` method (see **Program.cs Template** above)
5. **Keep it focused**: One principle or pattern per project, minimal dependencies
6. **Test the project standalone** before adding to StudyPresentation:
   ```bash
   cd YourNewProject
   dotnet run
   ```

### Step 2: Add to StudyPresentation (4-File Checklist)

**File 1: StudyPresentation.csproj**
- Add `<ProjectReference Include="../YourNewProject/YourProject.csproj" />`

**File 2: SolidPresenter.cs or PatternsPresenter.cs** (depending on type)
- Add `using YourProjectDemo = YourNamespace.PrincipleDemo;` (or `PatternDemo`) at the top
- Add a new `Lesson` entry to the `lessons` array (see **Presenter Slide Template** section below)

**File 3: README.md**
- Add a row to the appropriate table (SOLID Principles or Design Patterns)
- Include project name, principle/pattern name, brief one-line example

**File 4: Validation** (see **Validation Checklist** below)
- Verify the menu shows the new option
- Test the slide renders with correct colors and spacing

### Optional Step 3: Demonstrate Bad Design
As done in the Liskov slide, add a `BadDesignSample` property to the Lesson record to show an anti-pattern before revealing the correct approach. This helps learners understand the *why*, not just the *how*.

## Key Patterns in Agent Work

### When Reviewing or Adding Code
- **Preserve clarity**: Educational code should be immediately understandable
- **Minimal scope**: Each project teaches one concept; avoid coupling multiple ideas
- **Strong contracts**: Use interfaces and abstract classes to define clear boundaries
- **Avoid over-engineering**: Keep examples simple enough to fit on a presentation slide

### When Editing Demo Classes
- Keep `Run()` method ~20 lines or less (it fits on a screen during presentation)
- Use descriptive variable names and comments
- Show both the setup and the observable output (usually via `Console.WriteLine`)
- Avoid complex recursion, reflection, or hidden side effects

### When Adding Presenter Slides (StudyPresentation)
- Follow the color scheme: Cyan for headers, Red for warnings, Green for results, Yellow for code
- Show principle/pattern name, key decision, code excerpt, and live result
- Wait for keystroke between slides for presenter-controlled pacing
- See `SolidPresenter.cs` and `PatternsPresenter.cs` for patterns

### Presenter Slide Template

Slides are created as `Lesson` records in `SolidPresenter.cs` or `PatternsPresenter.cs`. Here's the pattern:

```csharp
new("Title of Principle/Pattern", 
    "One-sentence definition.", 
    "How this example applies the principle in one sentence.", 
    "When to use it: describe the real-world scenario.",
    """Code
    excerpt that
    fits on one screen""",
    YourDemo.Run),  // Calls the public Run() from PrincipleDemo/PatternDemo

// OPTIONAL: Add a bad design example (shown in red before the correct code):
new("Title",
    "Definition.",
    "Key applied.",
    "When to use it.",
    "Code sample.",
    YourDemo.Run,
    """BadDesignSample
    class Violating { throw new NotSupportedException(); }
    """)
```

**Color rendering happens automatically via `ConsolePresentation.ShowLesson(lesson)`:**
- Cyan: Title and section headers
- Yellow: "Definition"
- Green: "Key applied in this code"
- DarkGreen: "When to use it"
- Red: Bad design label and code
- Magenta: "Code to discuss" label
- Blue: "Live result" label

**Example from SolidPresenter.cs:**
```csharp
new("L - Liskov Substitution Principle (LSP)", 
    "An implementation must preserve the promises made by its abstraction.", 
    "RestrictedPlayerAccount does not claim to support Withdraw; only RegularPlayerAccount can implement IWithdrawableAccount.", 
    "Use it whenever inheritance or an interface represents a capability that callers depend on.",
    """internal interface IWithdrawableAccount : IPlayerAccount
{
    void Withdraw(decimal amount);
}

static void WithdrawFrom(IWithdrawableAccount account, decimal amount)
{
    account.Withdraw(amount);
}""",
    LiskovSubstitutionDemo.Run, 
    """class RestrictedPlayerAccount : IPlayerAccount
{
    public void Withdraw(decimal amount) => throw new NotSupportedException();
}""")
```

## Validation Checklist for New Examples

Before submitting a new principle or pattern example, verify:

- [ ] **Run standalone**: `cd YourProject && dotnet run` produces clean output with no errors
- [ ] **Demo output matches principle**: The printed result clearly shows the principle/pattern in action (not abstract or hidden)
- [ ] **Program.cs follows template**: Namespace matches folder, public `Run()` method, main calls demo
- [ ] **StudyPresentation integration complete**: (1) .csproj reference added, (2) Presenter slide created, (3) Menu option appears, (4) README.md updated
- [ ] **Color rendering**: Launch `StudyPresentation`, navigate to your new slide, verify colors render correctly and text fits on screen
- [ ] **Keystroke pacing**: All "Press any key" prompts work; no timeouts or hidden input prompts
- [ ] **No external dependencies**: Project builds with only System.* namespaces (no NuGet packages)
- [ ] **Code fits on slide**: The code excerpt in the Lesson record is ≤ 12 lines and uses readable variable names

## Common Pitfalls to Avoid

1. **Mixing principles in one project**: Keep each isolated for clarity. One concept per project.
2. **Using external NuGet dependencies**: ❌ `Newtonsoft.Json`, `FluentAssertions`, logging frameworks. ✅ Only `System.*` namespaces. This is a pure educational tool with no external tool dependencies.
3. **Making demo output complex**: Simple, single-purpose console output is best. Avoid reflection, recursion, or hidden side effects.
4. **Breaking existing presentations**: If modifying a presenter, ensure all slides still run correctly and menu navigation works.
5. **Unclear namespace/class names**: Names should clearly indicate what concept is being demonstrated (not `Example1`, `Test`, etc.).
6. **Forgetting the StudyPresentation integration**: Creating a project but not adding it to the menu/presenter leaves it orphaned. Follow the 4-file checklist in **Step 2** above.

## Dependencies & Build

### No External NuGet Packages (By Design)

This project uses **only the .NET runtime** to remain teachable and dependency-free. This is intentional.

**❌ Never add:**
- Logging frameworks (`Serilog`, `NLog`)
- Testing frameworks (`xUnit`, `NUnit`, `MSTest`) — the project teaches *principles*, not TDD
- Data access libraries (`Entity Framework`, `Dapper`)
- JSON/serialization libraries (`Newtonsoft.Json`, `System.Text.Json` for complex types)
- Assertion libraries (`FluentAssertions`)
- Any third-party NuGet package

**✅ Always use:**
- `System.*` namespaces (collections, reflection, IO, threading, etc.)
- Built-in C# language features (records, primary constructors, sealed, nullable)
- Console.WriteLine for output

**Why?** External dependencies obscure the principle being taught. A learner studying Dependency Inversion shouldn't also learn "this project uses Serilog." Keep the focus on the design principle.

### Framework & Language Settings
- **Target framework**: .NET 10.0 (latest stable)
- **C# language version**: Latest (implicit with net10.0)
- **Implicit usings**: Enabled (`ImplicitUsings`)
- **Nullable reference types**: Enabled (`Nullable`)

### Build & Validation Commands

To verify the solution builds and all projects run:
```bash
# Build entire solution
dotnet build DesignPatternsDemo.sln

# Run the interactive presentation (main entry point)
cd StudyPresentation && dotnet run

# Test a specific principle/pattern project
cd SingleResponsability && dotnet run
cd StrategyPattern && dotnet run
```

## Useful Links

- [README.md](README.md) — Principle definitions, pattern descriptions, and example gallery
- [DesignPatternsDemo.sln](DesignPatternsDemo.sln) — Solution file with all project references

---

**Last Updated**: 2026-09-09  
**For**: AI coding agents assisting with this educational project
