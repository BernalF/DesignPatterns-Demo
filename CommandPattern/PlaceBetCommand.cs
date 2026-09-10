namespace CommandPattern;

// Capturing the request and its data in one value makes it possible to queue, log, or replay the action.
internal sealed record PlaceBetCommand(string PlayerId, decimal Amount) : ICommand
{
    public string Execute() => $"Bet placed for {PlayerId} with amount {Amount:C}.";
}
