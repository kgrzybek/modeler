using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Types;

namespace Modeler.Full.Sample.Conceptual.Concepts.Entities;

public class Manager : Entity
{
    public static Entity Create() => new Manager()
        .WithName("Manager")
        .WithAttribute("ManagesFromDate", Date.Create());
}