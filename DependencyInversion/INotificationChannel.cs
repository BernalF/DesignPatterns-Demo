namespace DependencyInversion;

internal interface INotificationChannel
{
    /// <summary>
    /// Sends a notification through the configured delivery channel.
    /// </summary>
    /// <param name="playerId">The player identifier receiving the notification.</param>
    /// <param name="message">The notification message body.</param>
    void Send(string playerId, string message);
}