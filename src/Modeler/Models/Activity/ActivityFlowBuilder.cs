namespace Modeler.Models.Activity;

public class ActivityFlowBuilder<TActivityFlow>
    where TActivityFlow : ActivityFlow, new()
{
    private readonly string _name;
    private readonly List<ActivityAction> _actions;
    private readonly List<ActivityDecision> _decisions;
    private ActivityNode? _startNode;
    private readonly Dictionary<string, int> _nodeIdCounters;

    public ActivityFlowBuilder(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Activity flow name cannot be empty.", nameof(name));
        }

        _name = name;
        _actions = new List<ActivityAction>();
        _decisions = new List<ActivityDecision>();
        _nodeIdCounters = new Dictionary<string, int>();
    }

    public ActivityAction AddAction(string name)
    {
        var action = new ActivityAction(name);
        _actions.Add(action);
        AssignIdentifier(action);

        _startNode ??= action;

        return action;
    }

    public ActivityDecision AddDecision(string name)
    {
        var decision = new ActivityDecision(name);
        _decisions.Add(decision);
        AssignIdentifier(decision);

        _startNode ??= decision;

        return decision;
    }

    public void StartFrom(ActivityNode node)
    {
        if (!_actions.Contains(node) && !_decisions.Contains(node))
        {
            throw new InvalidOperationException("Start node must belong to the activity flow.");
        }

        _startNode = node;
    }

    public void Connect(ActivityAction from, ActivityNode to)
    {
        EnsureNodeExists(from);
        EnsureNodeExists(to);

        from.SetNext(to);
    }

    public void ConnectToEnd(ActivityAction from)
    {
        EnsureNodeExists(from);

        from.SetNext(null);
    }

    public void AddBranch(ActivityDecision decision, string label, ActivityNode target)
    {
        EnsureNodeExists(decision);
        EnsureNodeExists(target);

        decision.AddBranch(label, target);
    }

    public void AddBranchToEnd(ActivityDecision decision, string label)
    {
        EnsureNodeExists(decision);

        decision.AddBranch(label, null);
    }

    public TActivityFlow Build()
    {
        if (_startNode == null)
        {
            throw new InvalidOperationException("Activity flow requires a start node.");
        }

        var activity = new TActivityFlow();
        activity.SetName(_name);
        activity.SetStartNode(_startNode);
        activity.SetActions(_actions);
        activity.SetDecisions(_decisions);
        activity.Validate();

        return activity;
    }

    private void EnsureNodeExists(ActivityNode node)
    {
        if (!_actions.Contains(node) && !_decisions.Contains(node))
        {
            throw new InvalidOperationException("Node is not registered in this activity flow.");
        }
    }

    private void AssignIdentifier(ActivityNode node)
    {
        var baseId = node.Name
            .Trim()
            .ToLowerInvariant()
            .Replace(" ", "_")
            .Replace("?", string.Empty)
            .Replace("-", "_")
            .Replace("/", "_");

        if (string.IsNullOrWhiteSpace(baseId))
        {
            baseId = node.GetType().Name.ToLowerInvariant();
        }

        if (_nodeIdCounters.TryGetValue(baseId, out var current))
        {
            current++;
            _nodeIdCounters[baseId] = current;
            node.SetId($"{baseId}_{current}");
        }
        else
        {
            _nodeIdCounters[baseId] = 1;
            node.SetId(baseId);
        }
    }
}
