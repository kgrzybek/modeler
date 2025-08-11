using Modeler.EventsFlowModel;

namespace Modeler.Full.Sample.EventsFlow.Events;

public class EmployeeChangedEvent : Event
{
    public static Event Create() => new EmployeeChangedEvent()
        .WithName("Employee Changed");
}