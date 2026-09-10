namespace DecoratorPattern;

internal sealed class PlayerRepository : IPlayerRepository
{
    public string GetPlayerName(int playerId) => $"Player {playerId} from database";
}
