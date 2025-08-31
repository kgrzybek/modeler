using Modeler.Models.Data;
using Modeler.Samples.HR.Data.Structure.Tables;
using Modeler.Views.Data.Sql;

namespace Modeler.Samples.HR.Data.Views.Sql;

public class SqlOrganizationUnitTableView : SqlStructureElementView
{
    public SqlOrganizationUnitTableView(DataModel dataModel) : base(dataModel.GetTable<OrganizationUnitTable>())
    {
    }
}