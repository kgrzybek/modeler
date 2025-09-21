using Modeler.Models.Data;
using Modeler.Models.Data.Relationships;
using Modeler.Models.Data.Relationships.Multiplicity;
using Modeler.Samples.HR.Components.System.Database.Structure.Tables;

namespace Modeler.Samples.HR.Components.System.Database.Structure;

public class OrganizationsDataModel
{
    public static void Create(DatabaseComponent model)
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