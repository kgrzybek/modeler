namespace Modeler.EventsFlowModel.Sample.Events;

public class EmployeeChangedEvent : Event
{
    public static Event Create() => new EmployeeChangedEvent()
        .WithName("Employee Changed");
}