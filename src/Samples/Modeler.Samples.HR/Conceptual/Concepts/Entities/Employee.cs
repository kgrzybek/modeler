using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Enums;
using Modeler.Samples.HR.Conceptual.Concepts.Types;

namespace Modeler.Samples.HR.Conceptual.Concepts.Entities;

public class Employee : Entity
{
    public static Entity Create() => new Employee()
        .WithName("Employee")
        .WithAttribute("FirstName", Text.Create())
        .WithAttribute("LastName", Text.Create())
        .WithAttribute("Gender", Gender.Create())
        .WithAttribute("ResidentialAddress", Address.Create());
}