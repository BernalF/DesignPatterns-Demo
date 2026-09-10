namespace StrategyPattern;

// The service delegates ranking to a strategy, so new algorithms do not require changes here.
internal sealed class GameCatalogService(IGameRankingStrategy rankingStrategy)
{
    public List<string> GetRankedGames(List<string> gameIds) => rankingStrategy.Rank(gameIds);
}
