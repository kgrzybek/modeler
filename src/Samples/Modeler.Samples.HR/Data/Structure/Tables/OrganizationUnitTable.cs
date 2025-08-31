using Modeler.Models.Data.Structure;
using Modeler.Samples.HR.Data.Structure.ColumnTypes;
using Modeler.Samples.HR.Data.Structure.Schemas;

namespace Modeler.Samples.HR.Data.Structure.Tables;

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