namespace StrategyPattern;

internal sealed class PopularityRanking : IGameRankingStrategy
{
    public List<string> Rank(List<string> gameIds)
    {
        return gameIds.OrderByDescending(g => g.GetHashCode() % 100).ToList();
    }
}
