namespace FactoryPattern;

internal interface IMessageSender
{
    string Send(string message);
}

internal sealed class EmailSender : IMessageSender
{
    public string Send(string message) => $"Email sent: {message}";
}

internal sealed class SmsSender : IMessageSender
{
    public string Send(string message) => $"SMS sent: {message}";
}

internal static class MessageSenderFactory
{
    public static IMessageSender Create(string channel) => channel.ToLowerInvariant() switch
    {
        "email" => new EmailSender(),
        "sms" => new SmsSender(),
        _ => throw new ArgumentOutOfRangeException(nameof(channel), "Unsupported message channel.")
    };
}

/// <summary>Runs the Factory pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Creates a message sender from a channel selection.</summary>
    public static void Run()
    {
        IMessageSender sender = MessageSenderFactory.Create("email");
        Console.WriteLine(sender.Send("Your order is confirmed."));
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}