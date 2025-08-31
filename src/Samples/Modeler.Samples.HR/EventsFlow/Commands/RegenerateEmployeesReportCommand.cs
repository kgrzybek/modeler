using Modeler.Models.EventsFlow;

namespace Modeler.Samples.HR.EventsFlow.Commands;

public class RegenerateEmployeesReportCommand : Command
{
    public static Command Create() => new RegenerateEmployeesReportCommand()
        .WithName("Regenerate Employees Report");
}