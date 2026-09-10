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
        new("Strategy", "Choose an interchangeable algorithm or policy at runtime.", "GameCatalogService receives IGameRankingStrategy.", "Use it for variants such as game ranking algorithms, filtering rules, sorting strategies, or recommendation engines.", """
        internal sealed class GameCatalogService(IGameRankingStrategy rankingStrategy)
        {
            public List<string> GetRankedGames(List<string> gameIds) => rankingStrategy.Rank(gameIds);
        }
        """, StrategyDemo.Run),
        new("Factory", "Centralize object creation when the concrete type varies.", "NotificationSenderFactory selects the INotificationSender implementation.", "Use it when configuration, input, or environment selects an implementation.", """
        INotificationSender sender = NotificationSenderFactory.Create("email");
        """, FactoryDemo.Run),
        new("Adapter", "Convert an incompatible API into the interface your application expects.", "LegacyPaymentAdapter translates ProcessWithdrawal into ProcessTransaction.", "Use it when integrating legacy code or third-party SDKs.", """
        bool ProcessWithdrawal(decimal amount) => provider.ProcessTransaction(amount) == "SUCCESS";
        """, AdapterDemo.Run),
        new("Decorator", "Add behavior by wrapping an object without changing its original class.", "CachedPlayerRepository wraps IPlayerRepository and preserves its API.", "Use it for cross-cutting behavior such as caching, logging, metrics, retries, or authorization.", """
        IPlayerRepository repository = new CachedPlayerRepository(new PlayerRepository());
        """, DecoratorDemo.Run),
        new("Command", "Represent a request or action as an object.", "PlaceBetCommand carries both the action and its required data (player and amount).", "Use it for queues, jobs, undo/redo, auditing, retries, or CQRS writes.", """
        ICommand command = new PlaceBetCommand("PLAYER_789", 50.00m);
        string result = invoker.Execute(command);
        """, CommandDemo.Run),
        new("Result Pattern", "Represent expected success or failure as a returned value.", "WithdrawalService returns Result<string> instead of using exceptions for validation.", "Use it for expected business failures such as invalid amount, insufficient balance, or verification pending.", """
        Result<string> result = withdrawalService.RequestWithdrawal(amount);
        if (!result.IsSuccess) return result.Error;
        """, ResultDemo.Run),
        new("CQRS", "Separate commands that change state from queries that read state.", "PlaceBetHandler writes; GetBetHistoryHandler reads.", "Use it when write workflows and read models have meaningfully different rules, performance needs, or permissions. Avoid it for simple CRUD.", """
        Guid id = placeBetHandler.Handle(new PlaceBetCommand("PLAYER_001", 50.00m));
        var history = betHistoryHandler.Handle(new GetBetHistoryQuery("PLAYER_001"));
        """, CqrsDemo.Run)
    ];
}