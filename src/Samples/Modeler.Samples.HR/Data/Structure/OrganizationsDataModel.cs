using Modeler.Models.Data;
using Modeler.Models.Data.Relationships;
using Modeler.Models.Data.Relationships.Multiplicity;
using Modeler.Samples.HR.Data.Structure.Tables;

namespace Modeler.Samples.HR.Data.Structure;

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