using AdapterDemo = AdapterPattern.PatternDemo;
using CommandDemo = CommandPattern.PatternDemo;
using CqrsDemo = CqrsPattern.PatternDemo;
using DecoratorDemo = DecoratorPattern.PatternDemo;
using FactoryDemo = FactoryPattern.PatternDemo;
using ResultDemo = ResultPattern.PatternDemo;
using StrategyDemo = StrategyPattern.PatternDemo;

namespace StudyPresentation;

/// <summary>Provides the interactive design-patterns study track.</summary>
internal static class PatternsPresenter
{
    /// <summary>Displays every design-pattern lesson.</summary>
    public static void Run()
    {
        foreach (Lesson lesson in lessons)
        {
            ConsolePresentation.ShowLesson(lesson);
        }
    }

    private static readonly Lesson[] lessons =
    [
        new("Strategy", "Choose an interchangeable algorithm or policy at runtime.", "CheckoutService receives IDiscountStrategy.", "Use it for variants such as discounts, shipping costs, validation rules, or retry policies.", """
        internal sealed class CheckoutService(IDiscountStrategy strategy)
        {
            public decimal CalculateTotal(decimal subtotal) => strategy.Apply(subtotal);
        }
        """, StrategyDemo.Run),
        new("Factory", "Centralize object creation when the concrete type varies.", "MessageSenderFactory selects the IMessageSender implementation.", "Use it when configuration, input, or environment selects an implementation.", """
        IMessageSender sender = MessageSenderFactory.Create("email");
        """, FactoryDemo.Run),
        new("Adapter", "Convert an incompatible API into the interface your application expects.", "LegacyPaymentAdapter translates Charge into ProcessPayment.", "Use it when integrating legacy code or third-party SDKs.", """
        bool Charge(decimal amount) => provider.ProcessPayment(amount) == "APPROVED";
        """, AdapterDemo.Run),
        new("Decorator", "Add behavior by wrapping an object without changing its original class.", "CachedProductCatalog wraps IProductCatalog and preserves its API.", "Use it for cross-cutting behavior such as caching, logging, metrics, retries, or authorization.", """
        IProductCatalog catalog = new CachedProductCatalog(new ProductCatalog());
        """, DecoratorDemo.Run),
        new("Command", "Represent a request or action as an object.", "SendWelcomeEmailCommand carries both the action and its required data.", "Use it for queues, jobs, undo/redo, auditing, retries, or CQRS writes.", """
        ICommand command = new SendWelcomeEmailCommand("developer@example.com");
        string result = invoker.Execute(command);
        """, CommandDemo.Run),
        new("Result Pattern", "Represent expected success or failure as a returned value.", "RegistrationService returns Result<string> instead of using exceptions for validation.", "Use it for expected business failures such as invalid input, missing resources, or rule violations.", """
        Result<string> result = registrationService.Register(email);
        if (!result.IsSuccess) return result.Error;
        """, ResultDemo.Run),
        new("CQRS", "Separate commands that change state from queries that read state.", "CreateOrderHandler writes; GetOrderSummaryHandler reads.", "Use it when write workflows and read models have meaningfully different rules, performance needs, or permissions. Avoid it for simple CRUD.", """
        Guid id = createOrderHandler.Handle(new CreateOrderCommand("Alex", 125m));
        OrderSummary? order = getOrderHandler.Handle(new GetOrderSummaryQuery(id));
        """, CqrsDemo.Run)
    ];
}