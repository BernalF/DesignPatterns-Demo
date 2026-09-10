namespace SingleResponsibility;

/// <summary>Represents a bet slip with placed bets and their amounts.</summary>
public class BetSlip(int id, string playerId, List<decimal> betAmounts)
{
    /// <summary>Gets or sets the bet slip identifier.</summary>
    public int Id { get; set; } = id;
    /// <summary>Gets or sets the player identifier.</summary>
    public string PlayerId { get; set; } = playerId;
    /// <summary>Gets or sets the bet amounts in the slip.</summary>
    public List<decimal> BetAmounts { get; set; } = betAmounts;

    /// <summary>Initializes an empty bet slip.</summary>
    public BetSlip() : this(0, string.Empty, [])
    {
    }
}