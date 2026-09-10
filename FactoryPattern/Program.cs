namespace FactoryPattern;

internal interface INotificationSender
{
    string Send(string message);
}

internal sealed class EmailSender : INotificationSender
{
    public string Send(string message) => $"Email notification: {message}";
}

internal sealed class SmsPushSender : INotificationSender
{
    public string Send(string message) => $"Push notification: {message}";
}

internal static class NotificationSenderFactory
{
    public static INotificationSender Create(string channel) => channel.ToLowerInvariant() switch
    {
        "email" => new EmailSender(),
        "push" => new SmsPushSender(),
        _ => throw new ArgumentOutOfRangeException(nameof(channel), "Unsupported notification channel.")
    };
}

/// <summary>Runs the Factory pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Creates a notification sender from a channel selection.</summary>
    public static void Run()
    {
        INotificationSender sender = NotificationSenderFactory.Create("email");
        Console.WriteLine(sender.Send("Your bet has been placed successfully."));
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}