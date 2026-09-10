namespace DecoratorPattern;

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
