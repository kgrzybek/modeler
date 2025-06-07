using Modeler.RestApiModel.Sample.Models.ApiModels;

namespace Modeler.RestApiModel.Sample.Models.Endpoints;

public class AddEmployeeEndpoint : Endpoint
{
    public static Endpoint Create() => new AddEmployeeEndpoint()
        .WithName("Add Employee")
        .WithMethod("POST")
        .WithPath("/employees")
        .WithRequestModel(AddEmployeeRequest.Create())
        .WithResponseModel(EmployeeModel.Create());
}
