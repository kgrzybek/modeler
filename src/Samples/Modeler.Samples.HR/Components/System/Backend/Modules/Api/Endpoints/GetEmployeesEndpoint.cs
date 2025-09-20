using Modeler.Models.Common.Elements;
using Modeler.Models.RestApi;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.ApiModels;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api.Endpoints;

public class GetEmployeesEndpoint : Endpoint
{
    public static Endpoint Create(ModelElementsRegistry elementsRegistry) => new GetEmployeesEndpoint()
        .WithName("Get Employees")
        .WithMethod("GET")
        .WithPath("/employees")
        .WithResponseModel(elementsRegistry.GetElement<EmployeesResponse>());
}
