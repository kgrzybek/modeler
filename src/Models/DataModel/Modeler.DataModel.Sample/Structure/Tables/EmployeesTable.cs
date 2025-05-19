using Modeler.DataModel.Sample.Structure.ColumnTypes;
using Modeler.DataModel.Sample.Structure.Schemas;
using Modeler.DataModel.Structure;

namespace Modeler.DataModel.Sample.Structure.Tables;

public class EmployeesTable : Table
{
    public static Table Create()
    {
        return new EmployeesTable()
            .InSchema(new OrganizationSchema())
            .WithName("employees")
            .WithColumnAsPrimaryKey("id", new UUID())
            .WithColumn("first_name", new Varchar(100), false)
            .WithColumn("last_name", new Varchar(100), false)
            .WithColumn("organization_unit_id", new UUID(), false);
    }
}