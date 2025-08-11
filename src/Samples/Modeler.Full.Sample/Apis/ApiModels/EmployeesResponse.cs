using Modeler.RestApiModel;
using Modeler.RestApiModel.Types;

namespace Modeler.Full.Sample.Apis.ApiModels;

public class EmployeesResponse : ApiObjectModel
{
    public static ApiObjectModel Create() => new EmployeesResponse()
        .WithName("EmployeesResponse")
        .WithAttribute("Employees", ArrayType.Create(ModelType.Create(EmployeeObjectModel.Create())), true);
}
