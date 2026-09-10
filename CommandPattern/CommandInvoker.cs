namespace CommandPattern;

internal sealed class CommandInvoker
{
    // The invoker works with any command, so cross-cutting behavior can be added without changing each command.
    public string Execute(ICommand command) => command.Execute();
}
