namespace LiskovSubstitution;

internal sealed class RegularPlayerAccount : IWithdrawableAccount
{
    public decimal Balance { get; private set; }

    /// <summary>
    /// Deposits winnings or funds into the regular player account.
    /// </summary>
    public void Deposit(decimal amount)
    {
        ValidatePositiveAmount(amount);
        Balance += amount;
    }

    /// <summary>
    /// Withdraws funds when the account has sufficient balance.
    /// </summary>
    public void Withdraw(decimal amount)
    {
        ValidatePositiveAmount(amount);

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient balance for withdrawal.");
        }

        Balance -= amount;
    }

    /// <summary>
    /// Ensures an operation receives a valid monetary value.
    /// </summary>
    private static void ValidatePositiveAmount(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "The amount must be greater than zero.");
        }
    }
}