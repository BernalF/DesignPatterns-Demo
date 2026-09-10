namespace InterfaceSegregation;

internal interface ISlotMachine
{
    /// <summary>
    /// Operates a slot machine game.
    /// </summary>
    /// <param name="gameId">The slot game identifier.</param>
    void Operate(string gameId);
}
