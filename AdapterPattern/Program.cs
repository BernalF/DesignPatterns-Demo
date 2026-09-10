namespace AdapterPattern;

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