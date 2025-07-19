using Modeler.Full.Sample.Apis.ApiModels;
using Modeler.RestApiModel.Types;

namespace Modeler.RestApiModel.Sample.Models.ApiModels;

public class EmployeesResponse : ApiObjectModel
{
    public static ApiObjectModel Create() => new EmployeesResponse()
        .WithName("EmployeesResponse")
        .WithAttribute("Employees", ArrayType.Create(ModelType.Create(EmployeeObjectModel.Create())), true);
}
