namespace InterfaceSegregation;

/// <summary>
/// Runs the Interface Segregation Principle console demonstration.
/// </summary>
public static class PrincipleDemo
{
    /// <summary>
    /// Uses only the printer and scanner capabilities required by each client.
    /// </summary>
    public static void Run()
    {
        IPrinter basicPrinter = new BasicPrinter();
        IPrinter multiFunctionPrinter = new MultiFunctionPrinter();
        IScanner scanner = new MultiFunctionPrinter();

        PrintReport(basicPrinter);
        PrintReport(multiFunctionPrinter);
        Console.WriteLine(scanner.Scan("September invoice"));
    }

    /// <summary>
    /// Prints a report through the focused printing contract.
    /// </summary>
    private static void PrintReport(IPrinter printer)
    {
        printer.Print("Monthly report");
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