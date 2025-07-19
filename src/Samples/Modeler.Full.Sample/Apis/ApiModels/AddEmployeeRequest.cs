using Modeler.RestApiModel;
using Modeler.RestApiModel.Types;

namespace Modeler.Full.Sample.Apis.ApiModels;

public class AddEmployeeRequest : ApiObjectModel
{
    public static ApiObjectModel Create() => new AddEmployeeRequest()
        .WithName("AddEmployeeRequest")
        .WithAttribute("FirstName", StringType.Create(), true)
        .WithAttribute("LastName", StringType.Create(), true);
}
