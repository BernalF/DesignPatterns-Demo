namespace FactoryPattern;

internal sealed class SmsPushSender : INotificationSender
{
    public string Send(string message) => $"Push notification: {message}";
}
