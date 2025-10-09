using Modeler.Models.Common.Elements;

namespace Modeler.Models.Activity;

public abstract class ActivityFlow : IElement
{
    private List<ActivityAction> _actions;
    private List<ActivityDecision> _decisions;
    private ActivityNode? _startNode;

    protected ActivityFlow()
    {
        _actions = new List<ActivityAction>();
        _decisions = new List<ActivityDecision>();
        Name = string.Empty;
        Id = string.Empty;
    }

    public string Name { get; private set; }

    public string Id { get; private set; }

    public ActivityNode StartNode => _startNode ?? throw new InvalidOperationException("Start node is not set.");

    public IReadOnlyCollection<ActivityAction> GetActions() => _actions.AsReadOnly();

    public IReadOnlyCollection<ActivityDecision> GetDecisions() => _decisions.AsReadOnly();

    public IEnumerable<ActivityTransition> GetTransitions()
    {
        foreach (var action in _actions)
        {
            if (action.Next != null)
            {
                yield return new ActivityTransition(action, action.Next, null);
            }
            else
            {
                yield return new ActivityTransition(action, null, null);
            }
        }

        foreach (var decision in _decisions)
        {
            foreach (var branch in decision.Branches)
            {
                yield return new ActivityTransition(decision, branch.Target, branch.Label);
            }
        }
    }

    internal void SetName(string name)
    {
        Name = name;
        Id = ElementIdGenerator.GenerateElementId(GetType(), name);
    }

    internal void SetStartNode(ActivityNode startNode)
    {
        _startNode = startNode;
    }

    internal void SetActions(List<ActivityAction> actions)
    {
        _actions = actions;
    }

    internal void SetDecisions(List<ActivityDecision> decisions)
    {
        _decisions = decisions;
    }

    internal void Validate()
    {
        if (_startNode == null)
        {
            throw new InvalidOperationException("Activity flow must define a start node.");
        }

        if (string.IsNullOrWhiteSpace(_startNode.Id))
        {
            throw new InvalidOperationException("Start node must have an identifier assigned.");
        }

        foreach (var action in _actions)
        {
            if (string.IsNullOrWhiteSpace(action.Id))
            {
                throw new InvalidOperationException($"Activity '{action.Name}' does not have an identifier assigned.");
            }
        }

        foreach (var decision in _decisions)
        {
            if (decision.Branches.Count < 2)
            {
                throw new InvalidOperationException($"Decision '{decision.Name}' must contain at least two branches.");
            }

            if (string.IsNullOrWhiteSpace(decision.Id))
            {
                throw new InvalidOperationException($"Decision '{decision.Name}' does not have an identifier assigned.");
            }
        }
    }
}
