using Modeler.Models.RestApi;
using Modeler.Models.RestApi.Types;

namespace Modeler.Samples.HR.Apis.ApiModels;

public class AddEmployeeRequest : ApiObjectModel
{
    public static ApiObjectModel Create() => new AddEmployeeRequest()
        .WithName("AddEmployeeRequest")
        .WithAttribute("FirstName", StringType.Create(), true)
        .WithAttribute("LastName", StringType.Create(), true);
}
