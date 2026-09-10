namespace SingleResponsibility;

/// <summary>
/// Runs the Single Responsibility Principle console demonstration.
/// </summary>
public static class PrincipleDemo
{
	/// <summary>
	/// Retrieves bet slips and delegates CSV creation to the exporter.
	/// </summary>
	public static void Run()
	{
		BetSlipRepository betSlipRepository = new();
		IExporter exporter = new CsvExporter();
		IEnumerable<BetSlip> betSlips = betSlipRepository.GetAll();

		exporter.Export(betSlips);
		Console.WriteLine("Process complete: BetSlips.csv was generated.");
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