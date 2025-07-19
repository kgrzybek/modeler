using Modeler.RestApiModel;
using Modeler.RestApiModel.Sample.Models.ApiModels;
using Models.Elements;

namespace Modeler.Full.Sample.Apis.Endpoints;

public class GetEmployeesEndpoint : Endpoint
{
    public static Endpoint Create(ModelElementsRegistry elementsRegistry) => new GetEmployeesEndpoint()
        .WithName("Get Employees")
        .WithMethod("GET")
        .WithPath("/employees")
        .WithResponseModel(elementsRegistry.GetElement<EmployeesResponse>());
}
