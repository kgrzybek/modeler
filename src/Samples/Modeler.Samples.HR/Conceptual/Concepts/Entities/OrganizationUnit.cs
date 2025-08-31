using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Types;

namespace Modeler.Samples.HR.Conceptual.Concepts.Entities;

public class OrganizationUnit : Entity
{
    public static Entity Create() => new OrganizationUnit()
        .WithName("Organization_Unit")
        .WithAttribute("Name", Text.Create())
        .WithAttribute("Address", Address.Create());
}