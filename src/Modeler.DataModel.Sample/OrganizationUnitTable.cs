using Modeler.DataModel.Sample.ColumnTypes;
using Modeler.DataModel.Structure;

namespace Modeler.DataModel.Sample;

public class OrganizationUnitTable : Table
{
    public static Table Create()
    {
        return new OrganizationUnitTable()
            .InSchema(new OrganizationSchema())
            .WithName("organization_units")
            .WithColumnAsPrimaryKey("id", new UUID())
            .WithColumn("name", new Varchar(100), false);
    }
}