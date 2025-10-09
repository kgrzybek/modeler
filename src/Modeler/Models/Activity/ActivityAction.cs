namespace Modeler.Models.Activity;

public class ActivityAction : ActivityNode
{
    private ActivityNode? _next;

    public ActivityAction(string name) : base(name)
    {
    }

    public ActivityNode? Next => _next;

    internal void SetNext(ActivityNode? next)
    {
        if (_next != null)
        {
            throw new InvalidOperationException($"Next node for activity '{Name}' is already set.");
        }

        _next = next;
    }
}
