namespace InterfaceSegregation;

internal interface ISlotMachine
{
    // Slot clients depend only on this capability and are not forced to implement live-dealer operations.
    /// <summary>
    /// Operates a slot machine game.
    /// </summary>
    /// <param name="gameId">The slot game identifier.</param>
    void Operate(string gameId);
}
