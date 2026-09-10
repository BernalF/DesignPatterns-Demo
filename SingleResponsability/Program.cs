namespace SingleResponsibility;

/// <summary>
/// Runs the Single Responsibility Principle console demonstration.
/// </summary>
public static class PrincipleDemo
{
	/// <summary>
	/// Retrieves students and delegates CSV creation to the exporter.
	/// </summary>
	public static void Run()
	{
		StudentRepository studentRepository = new();
		CsvExporter csvExporter = new();
		IEnumerable<Student> students = studentRepository.GetAll();

		csvExporter.Export(students);
		Console.WriteLine("Process complete: Students.csv was generated.");
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