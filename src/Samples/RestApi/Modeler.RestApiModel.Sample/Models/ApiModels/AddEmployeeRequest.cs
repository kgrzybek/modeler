namespace Modeler.RestApiModel.Sample.Models.ApiModels;

public class AddEmployeeRequest : ApiModel
{
    public static ApiModel Create() => new AddEmployeeRequest()
        .WithName("AddEmployeeRequest")
        .WithAttribute("FirstName", "string", true)
        .WithAttribute("LastName", "string", true);
}
