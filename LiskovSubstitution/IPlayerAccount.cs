namespace LiskovSubstitution;

internal interface IPlayerAccount
{
    // Restricted accounts can honor this smaller contract without falsely promising that withdrawals work.
    decimal Balance { get; }

    /// <summary>
    /// Deposits winnings or funds into the player account.
    /// </summary>
    /// <param name="amount">The positive amount to deposit.</param>
    void Deposit(decimal amount);
}

internal interface IWithdrawableAccount : IPlayerAccount
{
    // Callers can safely invoke Withdraw because every implementation explicitly supports this capability.
    /// <summary>
    /// Withdraws funds from a player account that allows withdrawals.
    /// </summary>
    /// <param name="amount">The positive amount to withdraw.</param>
    void Withdraw(decimal amount);
}