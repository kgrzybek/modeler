namespace Modeler.Models.EventsFlow;

public class EventTrigger
{
    public EventTrigger(Event @event)
    {
        Event = @event;
    }

    public Event Event { get; }
}