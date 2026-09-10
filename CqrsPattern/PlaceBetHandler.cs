namespace CqrsPattern;

internal sealed class PlaceBetHandler(BetStore store)
{
    public Guid Handle(PlaceBetCommand command) => store.Create(command);
}
