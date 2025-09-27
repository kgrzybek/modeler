namespace Modeler.Models.Activity;

public class ActivityDecisionBranch
{
    public ActivityDecisionBranch(string label, ActivityNode? target)
    {
        if (string.IsNullOrWhiteSpace(label))
        {
            throw new ArgumentException("Branch label cannot be empty.", nameof(label));
        }

        Label = label;
        Target = target;
    }

    public string Label { get; }

    public ActivityNode? Target { get; }
}
