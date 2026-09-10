namespace InterfaceSegregation;

internal interface ISlotMachine
{
    /// <summary>
    /// Operates a slot machine game.
    /// </summary>
    /// <param name="gameId">The slot game identifier.</param>
    void Operate(string gameId);
}

internal interface ISportsBettingTerminal
{
    /// <summary>
    /// Places a sports bet on the selected event.
    /// </summary>
    /// <param name="eventName">The name of the sports event.</param>
    /// <returns>The bet confirmation.</returns>
    string PlaceBet(string eventName);
}

internal sealed class SimpleSlotMachine : ISlotMachine
{
    /// <summary>
    /// Operates a slot machine without sports betting capabilities.
    /// </summary>
    public void Operate(string gameId)
    {
        Console.WriteLine($"Operating slot game: {gameId}");
    }
}

internal sealed class AdvancedGamingTerminal : ISlotMachine, ISportsBettingTerminal
{
    /// <summary>
    /// Operates a slot machine game.
    /// </summary>
    public void Operate(string gameId)
    {
        Console.WriteLine($"Operating slot game: {gameId}");
    }

    /// <summary>
    /// Places a sports bet through the terminal.
    /// </summary>
    public string PlaceBet(string eventName)
    {
        return $"Bet placed on: {eventName}";
    }
}