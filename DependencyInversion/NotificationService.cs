namespace DependencyInversion;

internal sealed class NotificationService
{
    private readonly IMessageSender messageSender;

    public NotificationService(IMessageSender messageSender)
    {
        this.messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
    }

    /// <summary>
    /// Sends the welcome notification through the injected abstraction.
    /// </summary>
    /// <param name="email">The recipient email address.</param>
    public void NotifyWelcome(string email)
    {
        messageSender.Send(email, "Welcome to the system.");
    }
}