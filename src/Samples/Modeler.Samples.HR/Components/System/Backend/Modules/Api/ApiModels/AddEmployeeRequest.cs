using Modeler.Models.RestApi;
using Modeler.Models.RestApi.Types;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api.ApiModels;

public class AddEmployeeRequest : ApiObjectModel
{
    public static ApiObjectModel Create() => new AddEmployeeRequest()
        .WithName("AddEmployeeRequest")
        .WithAttribute("FirstName", StringType.Create(), true)
        .WithAttribute("LastName", StringType.Create(), true);
}
