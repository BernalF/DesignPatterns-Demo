namespace CommandPattern;

internal sealed record PlaceBetCommand(string PlayerId, decimal Amount) : ICommand
{
    public string Execute() => $"Bet placed for {PlayerId} with amount {Amount:C}.";
}
