namespace DependencyInversion;

internal sealed class EmailSender : IMessageSender
{
    /// <summary>
    /// Simulates sending an email message.
    /// </summary>
    public void Send(string recipient, string message)
    {
        Console.WriteLine($"Email to {recipient}: {message}");
    }
}