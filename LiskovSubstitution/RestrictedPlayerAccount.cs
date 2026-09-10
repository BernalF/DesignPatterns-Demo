namespace LiskovSubstitution;

internal sealed class RestrictedPlayerAccount : IPlayerAccount
{
    public decimal Balance { get; private set; }

    /// <summary>
    /// Deposits funds into the restricted account (e.g., bonus funds, pending verification).
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