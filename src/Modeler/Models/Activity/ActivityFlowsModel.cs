using Modeler.Models.Common.Elements;
using Modeler.Models.Common.Models;

namespace Modeler.Models.Activity;

public abstract class ActivityFlowsModel : IModel
{
    private readonly List<ActivityFlow> _flows;

    protected ActivityFlowsModel(ModelElementsRegistry elementsRegistry)
    {
        _flows = elementsRegistry.GetElements<ActivityFlow>();
    }

    public ActivityFlow GetFlow<TActivityFlow>() where TActivityFlow : ActivityFlow
    {
        var flow = _flows.OfType<TActivityFlow>().SingleOrDefault();

        if (flow == null)
        {
            throw new Exception($"Activity flow of type {typeof(TActivityFlow)} is not registered.");
        }

        return flow;
    }

    public IReadOnlyCollection<ActivityFlow> GetFlows() => _flows.AsReadOnly();
}
