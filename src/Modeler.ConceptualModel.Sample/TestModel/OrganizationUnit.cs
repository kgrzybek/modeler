namespace Modeler.ConceptualModel.Sample.TestModel;

public class OrganizationUnit : Entity
{
    public static Entity Create() => new OrganizationUnit()
        .WithName("Organization_Unit")
        .WithAttribute("Name", Text.Create())
        .WithAttribute("Address", Address.Create());
}