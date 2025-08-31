using Modeler.Models.Data;
using Modeler.Samples.HR.Data.Structure.Tables;
using Modeler.Views.Data.Sql;

namespace Modeler.Samples.HR.Data.Views.Sql;

public class SqlEmployeesTableView : SqlStructureElementView
{
    public SqlEmployeesTableView(DataModel dataModel) : base(dataModel.GetTable<EmployeesTable>())
    {
    }
}