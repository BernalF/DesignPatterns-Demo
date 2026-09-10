namespace InterfaceSegregation;

internal sealed class SimpleSlotMachine : ISlotMachine
{
    /// <summary>
    /// Operates a slot machine without live dealer capabilities.
    /// </summary>
    public void Operate(string gameId)
    {
        Console.WriteLine($"Operating slot game: {gameId}");
    }
}
