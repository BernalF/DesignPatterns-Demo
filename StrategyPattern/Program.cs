namespace StrategyPattern;

internal interface IOddsCalculationStrategy
{
    decimal CalculateOdds(decimal baseOdds);
}

internal sealed class FixedOdds(decimal fixedRate) : IOddsCalculationStrategy
{
    public decimal CalculateOdds(decimal baseOdds) => fixedRate;
}

internal sealed class DynamicOdds(decimal multiplier) : IOddsCalculationStrategy
{
    public decimal CalculateOdds(decimal baseOdds) => baseOdds * multiplier;
}

internal sealed class BettingService(IOddsCalculationStrategy oddsStrategy)
{
    public decimal CalculateFinalOdds(decimal baseOdds) => oddsStrategy.CalculateOdds(baseOdds);
}

/// <summary>Runs the Strategy pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Calculates final odds using a selected odds calculation strategy.</summary>
    public static void Run()
    {
        BettingService bettingService = new(new FixedOdds(2.5m));
        Console.WriteLine($"Base odds: 2.0. Final odds with fixed strategy: {bettingService.CalculateFinalOdds(2.0m):F2}.");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}