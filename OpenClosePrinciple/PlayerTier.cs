namespace OpenClose
{
    /// <summary>Represents a player with a specific tier that affects commission calculation.</summary>
    public abstract class PlayerTier
    {
        /// <summary>Gets or sets the player identifier.</summary>
        public string PlayerId { get; set; }

        /// <summary>Gets or sets the total wagers placed by this player.</summary>
        public decimal TotalWagers { get; set; }

        protected PlayerTier(string playerId, decimal totalWagers)
        {
            PlayerId = playerId;
            TotalWagers = totalWagers;
        }

        /// <summary>Calculates the platform commission based on player tier and wagers.</summary>
        public abstract decimal CalculateCommission();
    }
}