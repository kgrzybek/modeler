using Modeler.DataModel.Relationships;
using Modeler.DataModel.Relationships.Multiplicity;
using Modeler.DataModel.Sample.Structure.Tables;

namespace Modeler.DataModel.Sample.Structure;

public class OrganizationsDataModel : TableRelationshipsModel
{
    public static void Create(DataModel model)
    {
        var organizationUnit = model.GetTable<OrganizationUnitTable>();
        var employee = model.GetTable<EmployeesTable>();
        
        model.AddRelationship(
            employee,
            "organization_unit_id",
            new ZeroOrMany(),
            organizationUnit,
            "id",
            new One());
    }
}