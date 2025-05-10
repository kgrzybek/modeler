namespace Modeler.EventsFlowModel.Sample.Events;

public class EmployeesReportRegeneratedEvent : Event
{
    public static Event Create() => new EmployeesReportRegeneratedEvent()
        .WithName("Employees Report Regenerated");
}