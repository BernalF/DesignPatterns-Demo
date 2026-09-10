namespace ResultPattern;

internal sealed record Result<T>(T? Value, string? Error)
{
    public bool IsSuccess => Error is null;

    public static Result<T> Success(T value) => new(value, null);

    public static Result<T> Failure(string error) => new(default, error);
}

internal sealed class WithdrawalService
{
    public Result<string> RequestWithdrawal(decimal amount) => amount > 0
        ? Result<string>.Success($"Withdrawal of {amount:C} approved.")
        : Result<string>.Failure("Withdrawal amount must be greater than zero.");
}

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