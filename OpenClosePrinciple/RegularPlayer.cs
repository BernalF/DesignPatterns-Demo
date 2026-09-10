namespace OpenClose
{
    /// <summary>Regular player tier with standard commission rate.</summary>
    public class RegularPlayer : PlayerTier
    {
        private const decimal COMMISSION_RATE = 0.05m; // 5% commission

        public RegularPlayer(string playerId, decimal totalBetAmount)
            : base(playerId, totalBetAmount) { }

        public override decimal CalculateCommission()
        {
            return COMMISSION_RATE * TotalBetAmount;
        }
    }
}