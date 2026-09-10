namespace StrategyPattern;

internal sealed class RecommendationRanking : IGameRankingStrategy
{
    public List<string> Rank(List<string> gameIds)
    {
        return gameIds.OrderBy(g => g).ToList();
    }
}
