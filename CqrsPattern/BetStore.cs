namespace CqrsPattern;

internal sealed class BetStore
{
    private readonly Dictionary<string, List<BetRecord>> playerBets = [];

    public Guid Create(PlaceBetCommand command)
    {
        Guid betId = Guid.NewGuid();
        var record = new BetRecord(betId, command.PlayerId, command.Amount, DateTime.UtcNow);
        
        if (!playerBets.ContainsKey(command.PlayerId))
            playerBets[command.PlayerId] = [];
        playerBets[command.PlayerId].Add(record);
        
        return betId;
    }

    public List<BetRecord> GetHistory(GetBetHistoryQuery query) 
        => playerBets.GetValueOrDefault(query.PlayerId, []);
}
