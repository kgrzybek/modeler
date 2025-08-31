using Modeler.Full.Sample.Data.Structure.Tables;
using Modeler.Views.Data.Sql;

namespace Modeler.Full.Sample.Data.Views.Sql;

public class SqlEmployeesTableView : SqlStructureElementView
{
    public SqlEmployeesTableView(DataModel.DataModel dataModel) : base(dataModel.GetTable<EmployeesTable>())
    {
    }
}