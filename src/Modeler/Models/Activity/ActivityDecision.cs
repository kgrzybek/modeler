namespace Modeler.Models.Activity;

public class ActivityDecision : ActivityNode
{
    private readonly List<ActivityDecisionBranch> _branches;

    public ActivityDecision(string name) : base(name)
    {
        _branches = new List<ActivityDecisionBranch>();
    }

    public IReadOnlyCollection<ActivityDecisionBranch> Branches => _branches.AsReadOnly();

    internal void AddBranch(string label, ActivityNode? target)
    {
        _branches.Add(new ActivityDecisionBranch(label, target));
    }
}
