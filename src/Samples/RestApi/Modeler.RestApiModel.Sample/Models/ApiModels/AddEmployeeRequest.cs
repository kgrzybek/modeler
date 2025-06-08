using Modeler.RestApiModel;

namespace Modeler.RestApiModel.Sample.Models.ApiModels;

public class AddEmployeeRequest : ApiModel
{
    public static ApiModel Create() => new AddEmployeeRequest()
        .WithName("AddEmployeeRequest")
        .WithAttribute("FirstName", StringType.Create(), true)
        .WithAttribute("LastName", StringType.Create(), true);
}
