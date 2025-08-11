using Modeler.Full.Sample.Apis.ApiModels;
using Modeler.RestApiModel;
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
