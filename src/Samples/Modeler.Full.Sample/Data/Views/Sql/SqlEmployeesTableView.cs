using Modeler.DataModel.PostgreSQL.Views.SQL.Generator;
using Modeler.Full.Sample.Data.Structure.Tables;

namespace Modeler.Full.Sample.Data.Views.Sql;

public class SqlEmployeesTableView : SqlStructureElementView
{
    public SqlEmployeesTableView(DataModel.DataModel dataModel) : base(dataModel.GetTable<EmployeesTable>())
    {
    }
}