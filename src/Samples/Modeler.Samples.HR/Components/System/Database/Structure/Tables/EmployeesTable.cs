using Modeler.Models.Data.Structure;
using Modeler.Samples.HR.Components.System.Database.Structure.ColumnTypes;
using Modeler.Samples.HR.Components.System.Database.Structure.Schemas;

namespace Modeler.Samples.HR.Components.System.Database.Structure.Tables;

public class EmployeesTable : Table
{
    public static Table Create(ElementsRegistry elementsRegistry)
    {
        return new EmployeesTable()
            .InSchema(elementsRegistry.GetElement<OrganizationSchema>())
            .WithName("employees")
            .WithColumnAsPrimaryKey("id", new UUID())
            .WithColumn("first_name", new Varchar(100), false)
            .WithColumn("last_name", new Varchar(100), false)
            .WithColumn("organization_unit_id", new UUID(), false);
    }
}