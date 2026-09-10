namespace AdapterPattern;

internal interface IPaymentGateway
{
    bool Charge(decimal amount);
}

internal sealed class LegacyPaymentProvider
{
    public string ProcessPayment(decimal amount) => amount > 0 ? "APPROVED" : "DECLINED";
}

internal sealed class LegacyPaymentAdapter(LegacyPaymentProvider provider) : IPaymentGateway
{
    public bool Charge(decimal amount) => provider.ProcessPayment(amount) == "APPROVED";
}

/// <summary>Runs the Adapter pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Uses a legacy payment provider through the application's payment contract.</summary>
    public static void Run()
    {
        IPaymentGateway paymentGateway = new LegacyPaymentAdapter(new LegacyPaymentProvider());
        Console.WriteLine($"Payment approved: {paymentGateway.Charge(49.99m)}");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}