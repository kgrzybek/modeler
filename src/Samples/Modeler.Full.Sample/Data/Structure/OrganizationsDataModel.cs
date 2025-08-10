using Modeler.DataModel.Relationships;
using Modeler.DataModel.Relationships.Multiplicity;
using Modeler.Full.Sample.Data.Structure.Tables;

namespace Modeler.Full.Sample.Data.Structure;

public class OrganizationsDataModel : TableRelationshipsModel
{
    public static void Create(DataModel.DataModel model)
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