using Modeler.Models.EventsFlow;

namespace Modeler.Samples.HR.EventsFlow.Events;

public class EmployeeChangedEvent : Event
{
    public static Event Create() => new EmployeeChangedEvent()
        .WithName("Employee Changed");
}