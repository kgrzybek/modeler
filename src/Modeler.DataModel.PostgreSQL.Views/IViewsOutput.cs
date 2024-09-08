using Modeler.DataModel.PostgreSQL.Views.Generator;

namespace Modeler.DataModel.PostgreSQL.Views;

public interface IViewsOutput
{
    public void Execute(List<StructureItemViewItem> views);
}