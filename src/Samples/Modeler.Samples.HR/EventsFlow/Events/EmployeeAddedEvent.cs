using Modeler.Models.EventsFlow;

namespace Modeler.Samples.HR.EventsFlow.Events;

public class EmployeeAddedEvent : Event
{
    public static Event Create() => new EmployeeAddedEvent()
        .WithName("Employee Added");
}