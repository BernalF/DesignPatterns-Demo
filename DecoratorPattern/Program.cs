namespace DecoratorPattern;

/// <summary>Runs the Decorator pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Adds caching behavior without changing the player repository.</summary>
    public static void Run()
    {
        IPlayerRepository repository = new CachedPlayerRepository(new PlayerRepository());
        Console.WriteLine(repository.GetPlayerName(42));
        Console.WriteLine(repository.GetPlayerName(42));
        Console.WriteLine("The second call is served by the decorator cache.");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}