namespace OpenClose;

/// <summary>
/// Runs the Open/Closed Principle console demonstration.
/// </summary>
public static class PrincipleDemo
{
    /// <summary>
    /// Calculates and prints the commission for different player tiers.
    /// </summary>
    public static void Run()
    {
        CalculateCommissions(new List<PlayerTier>
        {
            new RegularPlayer("PLAYER_001", 5000m),
            new VipPlayer("PLAYER_002", 15000m)
        });
    }

    /// <summary>
    /// Prints each commission while relying on the player tier abstraction.
    /// </summary>
    private static void CalculateCommissions(List<PlayerTier> players)
    {
        foreach (PlayerTier player in players)
        {
            decimal commission = player.CalculateCommission();
            Console.WriteLine($"Player: {player.PlayerId}, Commission: {commission:C}");
        }
    }
}

internal static class Program
{
    /// <summary>
    /// Runs the demonstration when this project is executed directly.
    /// </summary>
    private static void Main()
    {
        PrincipleDemo.Run();
    }
}