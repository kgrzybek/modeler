using Modeler.ConceptualModel.Views.PlantUml.PlantUml;
using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.ConceptualModel.Sample.TestViews.Outputs;

public class MemoryViewOutput : IViewsOutput
{
    private List<ViewOutputItem> _views;

    public MemoryViewOutput()
    {
        _views = new List<ViewOutputItem>();
    }

    public void Execute(List<ViewOutputItem> views)
    {
        _views = views;
    }

    public List<ViewOutputItem> GetViews() => _views.ToList();
}