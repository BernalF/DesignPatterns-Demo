namespace ResultPattern;

/// <summary>Runs the Result pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Represents an expected validation failure as a value rather than an exception.</summary>
    public static void Run()
    {
        Result<string> result = new WithdrawalService().RequestWithdrawal(-100m);
        Console.WriteLine(result.IsSuccess ? result.Value : $"Validation error: {result.Error}");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}