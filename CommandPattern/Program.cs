namespace CommandPattern;

internal interface ICommand
{
    string Execute();
}

internal sealed record SendWelcomeEmailCommand(string Email) : ICommand
{
    public string Execute() => $"Welcome email sent to {Email}.";
}

internal sealed class CommandInvoker
{
    public string Execute(ICommand command) => command.Execute();
}

/// <summary>Runs the Command pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Wraps and executes an email action as a command object.</summary>
    public static void Run()
    {
        CommandInvoker invoker = new();
        Console.WriteLine(invoker.Execute(new SendWelcomeEmailCommand("developer@example.com")));
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}