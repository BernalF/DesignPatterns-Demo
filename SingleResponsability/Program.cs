namespace SingleResponsibility;

/// <summary>
/// Runs the Single Responsibility Principle console demonstration.
/// </summary>
public static class PrincipleDemo
{
	/// <summary>
	/// Retrieves bets and delegates CSV creation to the exporter.
	/// </summary>
	public static void Run()
	{
		BetRepository betRepository = new();
		IExporter exporter = new CsvExporter();
		IEnumerable<Bet> bets = betRepository.GetAll();

		exporter.Export(bets);
		Console.WriteLine("Process complete: Bets.csv was generated.");
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