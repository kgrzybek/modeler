using Modeler.DataModel.PostgreSQL.Views.SQL;
using Modeler.DataModel.PostgreSQL.Views.SQL.Generator;

namespace Modeler.Full.Sample.Data.Views.Outputs;

public class MemoryViewOutput : IViewsOutput
{
    public List<StructureItemViewItem> Views { get; private set; }
    
    public void Execute(List<StructureItemViewItem> views)
    {
        Views = views.ToList();
    }
}