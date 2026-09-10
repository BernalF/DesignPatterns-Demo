namespace AdapterPattern;

internal interface IWithdrawalProcessor
{
    bool ProcessWithdrawal(decimal amount);
}

internal sealed class LegacyPaymentProvider
{
    public string ProcessTransaction(decimal amount) => amount > 0 ? "SUCCESS" : "FAILED";
}

internal sealed class LegacyPaymentAdapter(LegacyPaymentProvider provider) : IWithdrawalProcessor
{
    public bool ProcessWithdrawal(decimal amount) => provider.ProcessTransaction(amount) == "SUCCESS";
}

/// <summary>Runs the Adapter pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Uses a legacy payment provider through the application's withdrawal contract.</summary>
    public static void Run()
    {
        IWithdrawalProcessor withdrawalProcessor = new LegacyPaymentAdapter(new LegacyPaymentProvider());
        Console.WriteLine($"Withdrawal approved: {withdrawalProcessor.ProcessWithdrawal(250.50m)}");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}