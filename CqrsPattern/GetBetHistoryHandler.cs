namespace CqrsPattern;

internal sealed class GetBetHistoryHandler(BetStore store)
{
    public List<BetRecord> Handle(GetBetHistoryQuery query) => store.GetHistory(query);
}
