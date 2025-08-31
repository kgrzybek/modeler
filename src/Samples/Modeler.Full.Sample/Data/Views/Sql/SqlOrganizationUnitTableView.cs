using Modeler.DataModel.PostgreSQL.Views.SQL.Generator;
using Modeler.Full.Sample.Data.Structure.Tables;

namespace Modeler.Full.Sample.Data.Views.Sql;

public class SqlOrganizationUnitTableView : SqlStructureElementView
{
    public SqlOrganizationUnitTableView(DataModel.DataModel dataModel) : base(dataModel.GetTable<OrganizationUnitTable>())
    {
    }
}