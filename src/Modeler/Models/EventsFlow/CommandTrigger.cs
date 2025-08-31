namespace Modeler.Models.EventsFlow;

public class CommandTrigger
{
    public CommandTrigger(Command command)
    {
        Command = command;
    }

    public Command Command { get; }
}