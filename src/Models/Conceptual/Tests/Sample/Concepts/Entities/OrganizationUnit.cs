using Modeler.ConceptualModel.Sample.Concepts.Types;

namespace Modeler.ConceptualModel.Sample.Concepts.Entities;

public class OrganizationUnit : Entity
{
    public static Entity Create() => new OrganizationUnit()
        .WithName("Organization_Unit")
        .WithAttribute("Name", Text.Create())
        .WithAttribute("Address", Address.Create());
}