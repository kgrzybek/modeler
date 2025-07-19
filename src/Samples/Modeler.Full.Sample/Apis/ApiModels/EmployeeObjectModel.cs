using Modeler.RestApiModel;
using Modeler.RestApiModel.Types;

namespace Modeler.Full.Sample.Apis.ApiModels;

public class EmployeeObjectModel : ApiObjectModel
{
    public static ApiObjectModel Create() => new EmployeeObjectModel()
        .WithName("Employee")
        .WithAttribute("Id", StringType.Create(), true)
        .WithAttribute("FirstName", StringType.Create(), true)
        .WithAttribute("LastName", StringType.Create(), true);
}
