using Modeler.DataModel.Structure;
using Modeler.DataModel.Tests.Sample.ColumnTypes;

namespace Modeler.DataModel.Tests.Sample;

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