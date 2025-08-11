using Modeler.EventsFlowModel;

namespace Modeler.Full.Sample.EventsFlow.Events;

public class EmployeeAddedEvent : Event
{
    public static Event Create() => new EmployeeAddedEvent()
        .WithName("Employee Added");
}