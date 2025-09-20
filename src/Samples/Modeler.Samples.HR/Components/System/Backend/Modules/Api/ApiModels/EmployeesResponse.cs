using Modeler.Models.RestApi;
using Modeler.Models.RestApi.Types;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api.ApiModels;

public class EmployeesResponse : ApiObjectModel
{
    public static ApiObjectModel Create() => new EmployeesResponse()
        .WithName("EmployeesResponse")
        .WithAttribute("Employees", ArrayType.Create(ModelType.Create(EmployeeObjectModel.Create())), true);
}
