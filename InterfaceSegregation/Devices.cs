namespace InterfaceSegregation;

internal interface IPrinter
{
    /// <summary>
    /// Prints the supplied document.
    /// </summary>
    /// <param name="document">The document to print.</param>
    void Print(string document);
}

internal interface IScanner
{
    /// <summary>
    /// Scans a physical document into a digital representation.
    /// </summary>
    /// <param name="documentName">The name assigned to the scanned document.</param>
    /// <returns>The scan result.</returns>
    string Scan(string documentName);
}

internal sealed class BasicPrinter : IPrinter
{
    /// <summary>
    /// Prints a document without requiring scan capabilities.
    /// </summary>
    public void Print(string document)
    {
        Console.WriteLine($"Printing: {document}");
    }
}

internal sealed class MultiFunctionPrinter : IPrinter, IScanner
{
    /// <summary>
    /// Prints the supplied document.
    /// </summary>
    public void Print(string document)
    {
        Console.WriteLine($"Printing: {document}");
    }

    /// <summary>
    /// Scans the supplied document name.
    /// </summary>
    public string Scan(string documentName)
    {
        return $"Scanned: {documentName}";
    }
}