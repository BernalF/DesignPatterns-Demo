namespace SingleResponsibility;

/// <summary>Represents a single bet placed by a player.</summary>
public class Bet(int id, string playerId, decimal amount)
{
    /// <summary>Gets or sets the bet identifier.</summary>
    public int Id { get; set; } = id;
    /// <summary>Gets or sets the player identifier.</summary>
    public string PlayerId { get; set; } = playerId;
    /// <summary>Gets or sets the bet amount.</summary>
    public decimal Amount { get; set; } = amount;

    /// <summary>Initializes an empty bet.</summary>
    public Bet() : this(0, string.Empty, 0)
    {
    }
}