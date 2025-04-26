using Modeler.DataModel.PostgreSQL.Views.SQL.Generator;

namespace Modeler.DataModel.PostgreSQL.Views.SQL;

public interface IViewsOutput
{
    public void Execute(List<StructureItemViewItem> views);
}