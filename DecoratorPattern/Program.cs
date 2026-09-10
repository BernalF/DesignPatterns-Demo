namespace DecoratorPattern;

internal interface IPlayerRepository
{
    string GetPlayerName(int playerId);
}

internal sealed class PlayerRepository : IPlayerRepository
{
    public string GetPlayerName(int playerId) => $"Player {playerId} from database";
}

internal sealed class CachedPlayerRepository(IPlayerRepository inner) : IPlayerRepository
{
    private readonly Dictionary<int, string> cache = [];

    public string GetPlayerName(int playerId)
    {
        if (!cache.TryGetValue(playerId, out string? playerName))
        {
            playerName = inner.GetPlayerName(playerId);
            cache[playerId] = playerName;
        }

        return playerName;
    }
}

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