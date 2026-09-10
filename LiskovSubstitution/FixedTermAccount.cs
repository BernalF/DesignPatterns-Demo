namespace LiskovSubstitution;

internal sealed class FixedTermAccount : IAccount
{
    public decimal Balance { get; private set; }

    /// <summary>
    /// Adds a positive amount to the fixed-term account.
    /// </summary>
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "The amount must be greater than zero.");
        }

        Balance += amount;
    }
}