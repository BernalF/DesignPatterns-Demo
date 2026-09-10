namespace InterfaceSegregation;

internal sealed class AdvancedGamingTerminal : ISlotMachine, ILiveDealerTable
{
    /// <summary>
    /// Operates a slot machine game.
    /// </summary>
    public void Operate(string gameId)
    {
        Console.WriteLine($"Operating slot game: {gameId}");
    }

    /// <summary>
    /// Opens a live dealer table from the same terminal.
    /// </summary>
    public string OpenTable(string tableName)
    {
        return $"Live table opened: {tableName}";
    }
}
