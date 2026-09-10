namespace FactoryPattern;

internal static class NotificationSenderFactory
{
    public static INotificationSender Create(string channel) => channel.ToLowerInvariant() switch
    {
        "email" => new EmailSender(),
        "push" => new SmsPushSender(),
        _ => throw new ArgumentOutOfRangeException(nameof(channel), "Unsupported notification channel.")
    };
}
