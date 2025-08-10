using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Enums;
using Modeler.Full.Sample.Conceptual.Concepts.Types;

namespace Modeler.Full.Sample.Conceptual.Concepts.Entities;

public class Employee : Entity
{
    public static Entity Create() => new Employee()
        .WithName("Employee")
        .WithAttribute("FirstName", Text.Create())
        .WithAttribute("LastName", Text.Create())
        .WithAttribute("Gender", Gender.Create())
        .WithAttribute("ResidentialAddress", Address.Create());
}