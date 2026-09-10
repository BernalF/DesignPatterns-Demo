namespace CqrsPattern;

internal sealed record CreateOrderCommand(string CustomerName, decimal Total);
internal sealed record GetOrderSummaryQuery(Guid OrderId);
internal sealed record OrderSummary(Guid Id, string CustomerName, decimal Total);

internal sealed class OrderStore
{
    private readonly Dictionary<Guid, OrderSummary> orders = [];

    public Guid Create(CreateOrderCommand command)
    {
        Guid orderId = Guid.NewGuid();
        orders[orderId] = new OrderSummary(orderId, command.CustomerName, command.Total);
        return orderId;
    }

    public OrderSummary? Get(GetOrderSummaryQuery query) => orders.GetValueOrDefault(query.OrderId);
}

internal sealed class CreateOrderHandler(OrderStore store)
{
    public Guid Handle(CreateOrderCommand command) => store.Create(command);
}

internal sealed class GetOrderSummaryHandler(OrderStore store)
{
    public OrderSummary? Handle(GetOrderSummaryQuery query) => store.Get(query);
}

/// <summary>Runs the CQRS pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Creates an order with a command and reads it with a separate query.</summary>
    public static void Run()
    {
        OrderStore store = new();
        Guid orderId = new CreateOrderHandler(store).Handle(new CreateOrderCommand("Alex", 125m));
        OrderSummary? order = new GetOrderSummaryHandler(store).Handle(new GetOrderSummaryQuery(orderId));
        Console.WriteLine($"Order {order?.Id}: {order?.CustomerName}, total {order?.Total:C}.");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}