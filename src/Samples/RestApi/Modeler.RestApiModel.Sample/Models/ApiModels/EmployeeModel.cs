using Modeler.RestApiModel;

namespace Modeler.RestApiModel.Sample.Models.ApiModels;

public class EmployeeModel : ApiModel
{
    public static ApiModel Create() => new EmployeeModel()
        .WithName("Employee")
        .WithAttribute("Id", StringType.Create(), true)
        .WithAttribute("FirstName", StringType.Create(), true)
        .WithAttribute("LastName", StringType.Create(), true);
}
