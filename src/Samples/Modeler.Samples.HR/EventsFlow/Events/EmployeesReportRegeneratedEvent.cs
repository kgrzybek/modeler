using Modeler.Models.EventsFlow;

namespace Modeler.Samples.HR.EventsFlow.Events;

public class EmployeesReportRegeneratedEvent : Event
{
    public static Event Create() => new EmployeesReportRegeneratedEvent()
        .WithName("Employees Report Regenerated");
}