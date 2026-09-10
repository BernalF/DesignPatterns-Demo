namespace FactoryPattern;

internal sealed class EmailSender : INotificationSender
{
    public string Send(string message) => $"Email notification: {message}";
}
