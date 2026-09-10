namespace StrategyPattern;

internal interface IDiscountStrategy
{
    decimal Apply(decimal subtotal);
}

internal sealed class PercentageDiscount(decimal percentage) : IDiscountStrategy
{
    public decimal Apply(decimal subtotal) => subtotal * (1 - percentage);
}

internal sealed class CheckoutService(IDiscountStrategy discountStrategy)
{
    public decimal CalculateTotal(decimal subtotal) => discountStrategy.Apply(subtotal);
}

/// <summary>Runs the Strategy pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Calculates a total using a selected discount strategy.</summary>
    public static void Run()
    {
        CheckoutService checkout = new(new PercentageDiscount(0.10m));
        Console.WriteLine($"Subtotal: {100m:C}. Total with 10% discount: {checkout.CalculateTotal(100m):C}.");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}