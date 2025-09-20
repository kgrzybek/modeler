using Modeler.Models.Data.Structure;
using Modeler.Samples.HR.Components.System.Database.Structure.ColumnTypes;
using Modeler.Samples.HR.Components.System.Database.Structure.Schemas;

namespace Modeler.Samples.HR.Components.System.Database.Structure.Tables;

public class OrganizationUnitTable : Table
{
    public static Table Create(ElementsRegistry elementsRegistry)
    {
        return new OrganizationUnitTable()
            .InSchema(elementsRegistry.GetElement<OrganizationSchema>())
            .WithName("organization_units")
            .WithColumnAsPrimaryKey("id", new UUID())
            .WithColumn("name", new Varchar(100), false);
    }
}