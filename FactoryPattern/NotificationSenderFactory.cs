namespace FactoryPattern;

internal static class NotificationSenderFactory
{
    // Centralizing construction keeps callers independent of concrete sender types and their setup rules.
    public static INotificationSender Create(string channel) => channel.ToLowerInvariant() switch
    {
        "email" => new EmailSender(),
        "push" => new SmsPushSender(),
        _ => throw new ArgumentOutOfRangeException(nameof(channel), "Unsupported notification channel.")
    };
}
