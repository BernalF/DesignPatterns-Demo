namespace LiskovSubstitution;

/// <summary>
/// Runs the Liskov Substitution Principle console demonstration.
/// </summary>
public static class PrincipleDemo
{
    /// <summary>
    /// Demonstrates that withdrawal clients only accept accounts with that capability.
    /// </summary>
    public static void Run()
    {
        IWithdrawableAccount regularAccount = new RegularPlayerAccount();
        regularAccount.Deposit(500_000m);
        WithdrawFrom(regularAccount, 125_000m);

        IPlayerAccount restrictedAccount = new RestrictedPlayerAccount();
        restrictedAccount.Deposit(1_000_000m);

        Console.WriteLine($"Regular player account: {regularAccount.Balance:C0}");
        Console.WriteLine($"Restricted player account: {restrictedAccount.Balance:C0}");
    }

    /// <summary>
    /// Withdraws funds only from an account that promises to support withdrawals.
    /// </summary>
    private static void WithdrawFrom(IWithdrawableAccount account, decimal amount)
    {
        account.Withdraw(amount);
    }
}

internal static class Program
{
    /// <summary>
    /// Runs the demonstration when this project is executed directly.
    /// </summary>
    private static void Main()
    {
        PrincipleDemo.Run();
    }
}