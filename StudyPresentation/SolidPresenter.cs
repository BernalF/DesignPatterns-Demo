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
        new("S - Single Responsibility Principle (SRP)", "A class should have one reason to change.", "StudentRepository retrieves students; CsvExporter creates a CSV.", "Use it when a class starts mixing business rules, persistence, formatting, or external delivery.", """
        IEnumerable<Student> students = repository.GetAll();
        exporter.Export(students);
        """, SingleResponsibilityDemo.Run),
        new("O - Open/Closed Principle (OCP)", "Software entities should be open for extension and closed for modification.", "The salary loop relies on Employee, so new employee types extend behavior without changing the loop.", "Use it when new variants are expected, such as payment methods, discounts, or employee types.", """
        foreach (Employee employee in employees)
        {
            decimal salary = employee.CalculateSalary();
        }
        """, OpenCloseDemo.Run),
        new("L - Liskov Substitution Principle (LSP)", "An implementation must preserve the promises made by its abstraction.", "FixedTermAccount does not claim to support Withdraw; only SavingsAccount can implement IWithdrawableAccount.", "Use it whenever inheritance or an interface represents a capability that callers depend on.", """
        internal interface IWithdrawableAccount : IAccount
        {
            void Withdraw(decimal amount);
        }

        static void WithdrawFrom(IWithdrawableAccount account, decimal amount)
        {
            account.Withdraw(amount);
        }
        """, LiskovSubstitutionDemo.Run, """
        class FixedTermAccount : IWithdrawableAccount
        {
            public void Withdraw(decimal amount) => throw new NotSupportedException();
        }
        """),
        new("I - Interface Segregation Principle (ISP)", "Clients should not depend on methods they do not use.", "BasicPrinter implements IPrinter only; scanning is a separate capability.", "Use it when a broad interface forces implementations to throw or provide meaningless methods.", """
        interface IPrinter { void Print(string document); }
        interface IScanner { string Scan(string documentName); }
        """, InterfaceSegregationDemo.Run),
        new("D - Dependency Inversion Principle (DIP)", "High-level modules should depend on abstractions, not concrete implementations.", "NotificationService receives IMessageSender instead of creating EmailSender itself.", "Use it at boundaries such as databases, HTTP APIs, messaging, storage, and external providers.", """
        internal sealed class NotificationService(IMessageSender sender)
        {
            // The service depends on the abstraction.
        }
        """, DependencyInversionDemo.Run)
    ];
}