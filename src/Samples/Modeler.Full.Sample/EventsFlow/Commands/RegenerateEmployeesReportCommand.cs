using Modeler.EventsFlowModel;

namespace Modeler.Full.Sample.EventsFlow.Commands;

public class RegenerateEmployeesReportCommand : Command
{
    public static Command Create() => new RegenerateEmployeesReportCommand()
        .WithName("Regenerate Employees Report");
}