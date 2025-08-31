using Modeler.Models.EventsFlow;

namespace Modeler.Samples.HR.EventsFlow.Commands;

public class AddEmployeeCommand : Command
{
    public static Command Create() => new AddEmployeeCommand()
        .WithName("Add Employee");
}