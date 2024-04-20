namespace Modeler.ConceptualModel.Sample.TestModel;

public class Employee : Entity
{
    public static Entity Create() => new Employee()
        .WithName("Employee")
        .WithAttribute("FirstName", Text.Create())
        .WithAttribute("LastName", Text.Create())
        .WithAttribute("Gender", Gender.Create())
        .WithAttribute("ResidentialAddress", Address.Create());
}