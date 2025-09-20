using Modeler.Models.Data;
using Modeler.Samples.HR.Components.System.Database.Structure.Tables;
using Modeler.Views.Data.Sql;

namespace Modeler.Samples.HR.Components.System.Database.Views.Sql;

public class SqlOrganizationUnitTableView : SqlStructureElementView
{
    public SqlOrganizationUnitTableView(DatabaseComponent dataModel) : base(dataModel.GetTable<OrganizationUnitTable>())
    {
    }
}