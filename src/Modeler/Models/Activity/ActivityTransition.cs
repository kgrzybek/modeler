namespace Modeler.Models.Activity;

public class ActivityTransition
{
    public ActivityTransition(ActivityNode source, ActivityNode? target, string? label)
    {
        Source = source;
        Target = target;
        Label = label;
    }

    public ActivityNode Source { get; }

    public ActivityNode? Target { get; }

    public string? Label { get; }
}
