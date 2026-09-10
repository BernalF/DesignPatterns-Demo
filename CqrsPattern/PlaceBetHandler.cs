namespace CqrsPattern;

// This write handler accepts only commands, keeping state changes separate from read operations.
internal sealed class PlaceBetHandler(BetStore store)
{
    public Guid Handle(PlaceBetCommand command) => store.Create(command);
}
