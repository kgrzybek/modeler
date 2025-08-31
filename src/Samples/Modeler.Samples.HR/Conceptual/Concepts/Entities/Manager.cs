using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Types;

namespace Modeler.Samples.HR.Conceptual.Concepts.Entities;

public class Manager : Entity
{
    public static Entity Create() => new Manager()
        .WithName("Manager")
        .WithAttribute("ManagesFromDate", Date.Create());
}