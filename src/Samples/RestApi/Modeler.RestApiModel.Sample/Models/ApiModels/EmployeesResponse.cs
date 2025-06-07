namespace Modeler.RestApiModel.Sample.Models.ApiModels;

public class EmployeesResponse : ApiModel
{
    public static ApiModel Create() => new EmployeesResponse()
        .WithName("EmployeesResponse")
        .WithAttribute("Employees", "Employee[]", true);
}
