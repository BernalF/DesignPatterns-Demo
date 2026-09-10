namespace OpenClose
{
    /// <summary>VIP player tier with higher commission rate and loyalty bonus.</summary>
    public class VipPlayer : PlayerTier
    {
        private const decimal BASE_COMMISSION_RATE = 0.08m; // 8% base commission
        private const decimal LOYALTY_BONUS = 0.02m; // 2% extra for high volume

        public VipPlayer(string playerId, decimal totalWagers) : base(playerId, totalWagers)
        {
        }

        public override decimal CalculateCommission()
        {
            decimal commission = BASE_COMMISSION_RATE * TotalWagers;

            if (TotalWagers > 10000m)
            {
                decimal bonusAmount = LOYALTY_BONUS * (TotalWagers - 10000m);
                commission += bonusAmount;
            }

            return commission;
        }
    }
}