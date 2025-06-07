using Modeler.RestApiModel.Sample.Models.ApiModels;

namespace Modeler.RestApiModel.Sample.Models.Endpoints;

public class GetEmployeesEndpoint : Endpoint
{
    public static Endpoint Create() => new GetEmployeesEndpoint()
        .WithName("Get Employees")
        .WithMethod("GET")
        .WithPath("/employees")
        .WithResponseModel(EmployeesResponse.Create());
}
