namespace StrategyPattern;

internal sealed class GameCatalogService(IGameRankingStrategy rankingStrategy)
{
    public List<string> GetRankedGames(List<string> gameIds) => rankingStrategy.Rank(gameIds);
}
