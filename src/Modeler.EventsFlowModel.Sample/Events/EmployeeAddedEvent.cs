namespace Modeler.EventsFlowModel.Sample.Events;

public class EmployeeAddedEvent : Event
{
    public static Event Create() => new EmployeeAddedEvent()
        .WithName("Employee Added");
}