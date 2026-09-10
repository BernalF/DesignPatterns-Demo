namespace DependencyInversion;

/// <summary>
/// Runs the Dependency Inversion Principle console demonstration.
/// </summary>
public static class PrincipleDemo
{
	/// <summary>
	/// Creates a high-level notification service with an injected message abstraction.
	/// </summary>
	public static void Run()
	{
		IMessageSender messageSender = new EmailSender();
		NotificationService notificationService = new(messageSender);

		notificationService.NotifyWelcome("user@example.com");
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