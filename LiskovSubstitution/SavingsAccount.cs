namespace LiskovSubstitution;

internal sealed class SavingsAccount : IWithdrawableAccount
{
    public decimal Balance { get; private set; }

    /// <summary>
    /// Adds a positive amount to the savings account.
    /// </summary>
    public void Deposit(decimal amount)
    {
        ValidatePositiveAmount(amount);
        Balance += amount;
    }

    /// <summary>
    /// Withdraws a positive amount when the account has sufficient funds.
    /// </summary>
    public void Withdraw(decimal amount)
    {
        ValidatePositiveAmount(amount);

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient balance.");
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