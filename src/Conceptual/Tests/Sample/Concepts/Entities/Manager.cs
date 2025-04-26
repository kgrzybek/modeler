using Modeler.ConceptualModel.Sample.Concepts.Types;

namespace Modeler.ConceptualModel.Sample.Concepts.Entities;

public class Manager : Entity
{
    public static Entity Create() => new Manager()
        .WithName("Manager")
        .WithAttribute("ManagesFromDate", Date.Create());
}