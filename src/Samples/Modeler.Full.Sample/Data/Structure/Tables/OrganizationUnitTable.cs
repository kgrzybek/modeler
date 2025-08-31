using Modeler.DataModel.Structure;
using Modeler.Full.Sample.Data.Structure.ColumnTypes;
using Modeler.Full.Sample.Data.Structure.Schemas;

namespace Modeler.Full.Sample.Data.Structure.Tables;

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