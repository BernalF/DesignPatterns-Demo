namespace CommandPattern;

internal interface ICommand
{
    string Execute();
}

internal sealed record PlaceBetCommand(string PlayerId, decimal Amount) : ICommand
{
    public string Execute() => $"Bet placed for {PlayerId} with amount {Amount:C}.";
}

internal sealed class CommandInvoker
{
    public string Execute(ICommand command) => command.Execute();
}

/// <summary>Runs the Command pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Wraps and executes a betting action as a command object.</summary>
    public static void Run()
    {
        CommandInvoker invoker = new();
        Console.WriteLine(invoker.Execute(new PlaceBetCommand("PLAYER_789", 50.00m)));
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}