using DependencyInversionDemo = DependencyInversion.PrincipleDemo;
using InterfaceSegregationDemo = InterfaceSegregation.PrincipleDemo;
using LiskovSubstitutionDemo = LiskovSubstitution.PrincipleDemo;
using OpenCloseDemo = OpenClose.PrincipleDemo;
using SingleResponsibilityDemo = SingleResponsibility.PrincipleDemo;

namespace StudyPresentation;

/// <summary>Provides the interactive SOLID principles study track.</summary>
internal static class SolidPresenter
{
    /// <summary>Displays every SOLID lesson.</summary>
    public static void Run()
    {
        foreach (Lesson lesson in lessons)
        {
            ConsolePresentation.ShowLesson(lesson);
        }
    }

    private static readonly Lesson[] lessons =
    [
        new("S - Single Responsibility Principle (SRP)", "A class should have one reason to change.", "BetRepository retrieves bets; CsvExporter creates a CSV export.", "Use it when a class starts mixing business rules, persistence, formatting, or external delivery.", """
        IEnumerable<Bet> bets = repository.GetAll();
        exporter.Export(bets);
        """, SingleResponsibilityDemo.Run),
        new("O - Open/Closed Principle (OCP)", "Software entities should be open for extension and closed for modification.", "The commission calculation loop relies on PlayerTier, so new tier types extend behavior without changing the loop.", "Use it when new variants are expected, such as player tiers, bet types, or calculation strategies.", """
        foreach (PlayerTier player in players)
        {
            decimal commission = player.CalculateCommission();
        }
        """, OpenCloseDemo.Run),
        new("L - Liskov Substitution Principle (LSP)", "An implementation must preserve the promises made by its abstraction.", "RestrictedPlayerAccount does not claim to support Withdraw; only RegularPlayerAccount can implement IWithdrawableAccount.", "Use it whenever inheritance or an interface represents a capability that callers depend on.", """
        internal interface IWithdrawableAccount : IPlayerAccount
        {
            void Withdraw(decimal amount);
        }

        static void WithdrawFrom(IWithdrawableAccount account, decimal amount)
        {
            account.Withdraw(amount);
        }
        """, LiskovSubstitutionDemo.Run, """
        class RestrictedPlayerAccount : IWithdrawableAccount
        {
            public void Withdraw(decimal amount) => throw new NotSupportedException();
        }
        """),
        new("I - Interface Segregation Principle (ISP)", "Clients should not depend on methods they do not use.", "SimpleSlotMachine implements ISlotMachine only; live dealer access is a separate capability.", "Use it when a broad interface forces implementations to throw or provide meaningless methods.", """
        interface ISlotMachine { void Operate(string gameId); }
        interface ILiveDealerTable { string OpenTable(string tableName); }
        """, InterfaceSegregationDemo.Run),
        new("D - Dependency Inversion Principle (DIP)", "High-level modules should depend on abstractions, not concrete implementations.", "PlayerNotificationService receives INotificationChannel instead of creating EmailNotificationChannel itself.", "Use it at boundaries such as databases, HTTP APIs, messaging, storage, and external providers.", """
        internal sealed class PlayerNotificationService(INotificationChannel channel)
        {
            // The service depends on the abstraction.
        }
        """, DependencyInversionDemo.Run)
    ];
}