
using Modeler.DataModel.PostgreSQL.Views;
using Modeler.DataModel.PostgreSQL.Views.Generator;

namespace Modeler.DataModel.Tests.Sample;

public class MemoryViewOutput : IViewsOutput
{
    public List<StructureItemViewItem> Views { get; private set; }
    
    public void Execute(List<StructureItemViewItem> views)
    {
        Views = views.ToList();
    }
}