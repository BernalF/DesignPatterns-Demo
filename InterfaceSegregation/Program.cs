namespace InterfaceSegregation;

/// <summary>
/// Runs the Interface Segregation Principle console demonstration.
/// </summary>
public static class PrincipleDemo
{
    /// <summary>
    /// Uses only the gaming capabilities required by each terminal client.
    /// </summary>
    public static void Run()
    {
        ISlotMachine simpleSlot = new SimpleSlotMachine();
        ISlotMachine advancedTerminal = new AdvancedGamingTerminal();
        ISportsBettingTerminal sportsTerminal = new AdvancedGamingTerminal();

        OperateSlot(simpleSlot);
        OperateSlot(advancedTerminal);
        Console.WriteLine(sportsTerminal.PlaceBet("Champions League Final"));
    }

    /// <summary>
    /// Operates a slot machine through the focused gaming contract.
    /// </summary>
    private static void OperateSlot(ISlotMachine machine)
    {
        machine.Operate("Mega Jackpot Slots");
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