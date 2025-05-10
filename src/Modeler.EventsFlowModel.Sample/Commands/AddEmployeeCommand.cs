namespace Modeler.EventsFlowModel.Sample.Commands;

public class AddEmployeeCommand : Command
{
    public static Command Create() => new AddEmployeeCommand()
        .WithName("Add Employee");
}