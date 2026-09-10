namespace LiskovSubstitution;

internal interface IPlayerAccount
{
    decimal Balance { get; }

    /// <summary>
    /// Deposits winnings or funds into the player account.
    /// </summary>
    /// <param name="amount">The positive amount to deposit.</param>
    void Deposit(decimal amount);
}

internal interface IWithdrawableAccount : IPlayerAccount
{
    /// <summary>
    /// Withdraws funds from a player account that allows withdrawals.
    /// </summary>
    /// <param name="amount">The positive amount to withdraw.</param>
    void Withdraw(decimal amount);
}