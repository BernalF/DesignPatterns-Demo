namespace DependencyInversion;

internal sealed class EmailNotificationChannel : INotificationChannel
{
    /// <summary>
    /// Simulates sending an email notification to a player.
    /// </summary>
    public void Send(string playerId, string message)
    {
        Console.WriteLine($"Email to {playerId}: {message}");
    }
}