namespace Modeler.EventsFlowModel.Sample.Commands;

public class RegenerateEmployeesReportCommand : Command
{
    public static Command Create() => new RegenerateEmployeesReportCommand()
        .WithName("Regenerate Employees Report");
}