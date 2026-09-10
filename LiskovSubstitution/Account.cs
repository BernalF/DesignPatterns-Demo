namespace LiskovSubstitution;

internal interface IAccount
{
    decimal Balance { get; }

    /// <summary>
    /// Adds money to the account.
    /// </summary>
    /// <param name="amount">The positive amount to deposit.</param>
    void Deposit(decimal amount);
}

internal interface IWithdrawableAccount : IAccount
{
    /// <summary>
    /// Removes money from an account that allows withdrawals.
    /// </summary>
    /// <param name="amount">The positive amount to withdraw.</param>
    void Withdraw(decimal amount);
}