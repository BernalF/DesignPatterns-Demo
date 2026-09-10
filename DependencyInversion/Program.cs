namespace DependencyInversion;

/// <summary>
/// Runs the Dependency Inversion Principle console demonstration.
/// </summary>
public static class PrincipleDemo
{
	/// <summary>
	/// Creates a high-level notification service with an injected notification channel abstraction.
	/// </summary>
	public static void Run()
	{
		INotificationChannel notificationChannel = new EmailNotificationChannel();
		PlayerNotificationService notificationService = new(notificationChannel);

		notificationService.NotifyWelcome("PLAYER_12345");
	}
}

internal static class Program
{
	/// <summary>
	/// Runs the demonstration when this project is executed directly.
	/// </summary>
	private static void Main()
	{
		PrincipleDemo.Run();
	}
}