namespace DecoratorPattern;

internal interface IProductCatalog
{
    string GetProductName(int productId);
}

internal sealed class ProductCatalog : IProductCatalog
{
    public string GetProductName(int productId) => $"Product {productId} from database";
}

internal sealed class CachedProductCatalog(IProductCatalog inner) : IProductCatalog
{
    private readonly Dictionary<int, string> cache = [];

    public string GetProductName(int productId)
    {
        if (!cache.TryGetValue(productId, out string? productName))
        {
            productName = inner.GetProductName(productId);
            cache[productId] = productName;
        }

        return productName;
    }
}

/// <summary>Runs the Decorator pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Adds caching behavior without changing the product catalog.</summary>
    public static void Run()
    {
        IProductCatalog catalog = new CachedProductCatalog(new ProductCatalog());
        Console.WriteLine(catalog.GetProductName(7));
        Console.WriteLine(catalog.GetProductName(7));
        Console.WriteLine("The second call is served by the decorator cache.");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}