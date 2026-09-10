namespace CommandPattern;

internal sealed class CommandInvoker
{
    public string Execute(ICommand command) => command.Execute();
}
