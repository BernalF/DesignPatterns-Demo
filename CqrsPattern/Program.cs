namespace CqrsPattern;

/// <summary>Runs the CQRS pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Places a bet with a command and reads bet history with a separate query.</summary>
    public static void Run()
    {
        BetStore store = new();
        new PlaceBetHandler(store).Handle(new PlaceBetCommand("PLAYER_001", 50.00m));
        new PlaceBetHandler(store).Handle(new PlaceBetCommand("PLAYER_001", 100.00m));
        var history = new GetBetHistoryHandler(store).Handle(new GetBetHistoryQuery("PLAYER_001"));
        Console.WriteLine($"Player PLAYER_001 has {history.Count} bet(s): {string.Join(", ", history.Select(b => $"{b.Amount:C}"))}.");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}