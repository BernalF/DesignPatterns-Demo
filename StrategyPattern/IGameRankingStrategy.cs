namespace StrategyPattern;

internal interface IGameRankingStrategy
{
    List<string> Rank(List<string> gameIds);
}
