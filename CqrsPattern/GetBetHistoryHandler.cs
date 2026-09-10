namespace CqrsPattern;

// This read handler accepts only queries, allowing the history path to evolve independently from bet placement.
internal sealed class GetBetHistoryHandler(BetStore store)
{
    public List<BetRecord> Handle(GetBetHistoryQuery query) => store.GetHistory(query);
}
