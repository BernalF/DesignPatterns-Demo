namespace DependencyInversion;

internal sealed class PlayerNotificationService
{
    // The business service depends on the channel contract, so delivery details can change independently.
    private readonly INotificationChannel notificationChannel;

    public PlayerNotificationService(INotificationChannel notificationChannel)
    {
        this.notificationChannel = notificationChannel ?? throw new ArgumentNullException(nameof(notificationChannel));
    }

    /// <summary>
    /// Sends a welcome notification to a player through the injected channel.
    /// </summary>
    /// <param name="playerId">The player identifier.</param>
    public void NotifyWelcome(string playerId)
    {
        notificationChannel.Send(playerId, "Welcome to our gaming platform!");
    }
}