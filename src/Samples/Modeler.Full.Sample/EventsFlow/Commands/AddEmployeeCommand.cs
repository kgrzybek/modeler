using Modeler.EventsFlowModel;

namespace Modeler.Full.Sample.EventsFlow.Commands;

public class AddEmployeeCommand : Command
{
    public static Command Create() => new AddEmployeeCommand()
        .WithName("Add Employee");
}