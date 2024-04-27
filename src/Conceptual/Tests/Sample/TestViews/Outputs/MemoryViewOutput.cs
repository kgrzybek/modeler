using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.ConceptualModel.Sample.TestViews.Outputs;

public class MemoryViewOutput<T> : IViewsOutput<T>
{
    private List<ViewOutputItem<T>> _views;

    public MemoryViewOutput()
    {
        _views = new List<ViewOutputItem<T>>();
    }

    public void Execute(List<ViewOutputItem<T>> views)
    {
        _views = views;
    }

    public List<ViewOutputItem<T>> GetViews() => _views.ToList();
}