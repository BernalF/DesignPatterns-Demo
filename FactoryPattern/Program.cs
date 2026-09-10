namespace FactoryPattern;

/// <summary>Runs the Factory pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Creates a notification sender from a channel selection.</summary>
    public static void Run()
    {
        INotificationSender sender = NotificationSenderFactory.Create("email");
        Console.WriteLine(sender.Send("Transaction completed successfully."));
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}