namespace Modeler.ConceptualModel.Sample.TestModel;

public class OrganizationUnit : Entity
{
    public static Entity Create() => new OrganizationUnit()
        .WithName("Organization Unit")
        .WithAttribute("Name", Text.Create());
}