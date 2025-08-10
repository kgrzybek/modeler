using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Types;

namespace Modeler.Full.Sample.Conceptual.Concepts.Entities;

public class OrganizationUnit : Entity
{
    public static Entity Create() => new OrganizationUnit()
        .WithName("Organization_Unit")
        .WithAttribute("Name", Text.Create())
        .WithAttribute("Address", Address.Create());
}