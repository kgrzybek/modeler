using Modeler.DataModel.Structure;
using Modeler.DataModel.Tests.Sample.ColumnTypes;

namespace Modeler.DataModel.Tests.Sample;

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