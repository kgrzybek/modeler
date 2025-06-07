namespace Modeler.RestApiModel.Sample.Models.ApiModels;

public class EmployeeModel : ApiModel
{
    public static ApiModel Create() => new EmployeeModel()
        .WithName("Employee")
        .WithAttribute("Id", "string", true)
        .WithAttribute("FirstName", "string", true)
        .WithAttribute("LastName", "string", true);
}
