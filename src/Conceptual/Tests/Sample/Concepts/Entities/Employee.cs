using Modeler.ConceptualModel.Sample.Concepts.Enums;
using Modeler.ConceptualModel.Sample.Concepts.Types;

namespace Modeler.ConceptualModel.Sample.Concepts.Entities;

public class Employee : Entity
{
    public static Entity Create() => new Employee()
        .WithName("Employee")
        .WithAttribute("FirstName", Text.Create())
        .WithAttribute("LastName", Text.Create())
        .WithAttribute("Gender", Gender.Create())
        .WithAttribute("ResidentialAddress", Address.Create());
}