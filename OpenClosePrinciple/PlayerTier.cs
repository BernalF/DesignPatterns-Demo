namespace OpenClose
{
    /// <summary>Represents a player with a specific tier that affects commission calculation.</summary>
    public abstract class PlayerTier
    {
        // New tiers extend this contract instead of changing existing commission calculations or callers.
        /// <summary>Gets or sets the player identifier.</summary>
        public string PlayerId { get; set; }

        /// <summary>Gets or sets the total amount bet by this player.</summary>
        public decimal TotalBetAmount { get; set; }

        protected PlayerTier(string playerId, decimal totalBetAmount)
        {
            PlayerId = playerId;
            TotalBetAmount = totalBetAmount;
        }

        /// <summary>Calculates the platform commission based on player tier and bet amount.</summary>
        public abstract decimal CalculateCommission();
    }
}