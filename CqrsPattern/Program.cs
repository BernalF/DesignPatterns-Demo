namespace CqrsPattern;

internal sealed record CreateBetCommand(string PlayerId, decimal Amount);
internal sealed record GetBetHistoryQuery(Guid BetId);
internal sealed record BetRecord(Guid Id, string PlayerId, decimal Amount);

internal sealed class BetStore
{
    private readonly Dictionary<Guid, BetRecord> bets = [];

    public Guid Create(CreateBetCommand command)
    {
        Guid betId = Guid.NewGuid();
        bets[betId] = new BetRecord(betId, command.PlayerId, command.Amount);
        return betId;
    }

    public BetRecord? Get(GetBetHistoryQuery query) => bets.GetValueOrDefault(query.BetId);
}

internal sealed class CreateBetHandler(BetStore store)
{
    public Guid Handle(CreateBetCommand command) => store.Create(command);
}

internal sealed class GetBetHistoryHandler(BetStore store)
{
    public BetRecord? Handle(GetBetHistoryQuery query) => store.Get(query);
}

/// <summary>Runs the CQRS pattern demonstration.</summary>
public static class PatternDemo
{
    /// <summary>Creates a bet with a command and reads it with a separate query.</summary>
    public static void Run()
    {
        BetStore store = new();
        Guid betId = new CreateBetHandler(store).Handle(new CreateBetCommand("PLAYER_001", 100m));
        BetRecord? bet = new GetBetHistoryHandler(store).Handle(new GetBetHistoryQuery(betId));
        Console.WriteLine($"Bet {bet?.Id}: Player {bet?.PlayerId}, amount {bet?.Amount:C}.");
    }
}

internal static class Program
{
    /// <summary>Runs the demonstration when executed directly.</summary>
    private static void Main() => PatternDemo.Run();
}