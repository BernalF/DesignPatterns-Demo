namespace StrategyPattern;

/// <summary>Runs the Strategy pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Ranks games using a selected ranking strategy.</summary>
    public static void Run()
    {
        GameCatalogService catalogService = new(new PopularityRanking());
        var games = new List<string> { "SlotMachine_001", "Roulette_042", "Blackjack_015" };
        var ranked = catalogService.GetRankedGames(games);
        Console.WriteLine($"Top game: {ranked[0]}");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}