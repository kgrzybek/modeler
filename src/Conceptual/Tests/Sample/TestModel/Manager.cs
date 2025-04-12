namespace Modeler.ConceptualModel.Sample.TestModel;

public class Manager : Entity
{
    public static Entity Create() => new Manager()
        .WithName("Manager")
        .WithAttribute("ManagesFromDate", Date.Create());
}