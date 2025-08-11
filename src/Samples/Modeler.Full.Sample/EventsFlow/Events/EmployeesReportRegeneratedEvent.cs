using Modeler.EventsFlowModel;

namespace Modeler.Full.Sample.EventsFlow.Events;

public class EmployeesReportRegeneratedEvent : Event
{
    public static Event Create() => new EmployeesReportRegeneratedEvent()
        .WithName("Employees Report Regenerated");
}