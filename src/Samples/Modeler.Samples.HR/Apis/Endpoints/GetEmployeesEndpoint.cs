using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.RestApi;
using Modeler.Samples.HR.Apis.ApiModels;

namespace Modeler.Samples.HR.Apis.Endpoints;

public class GetEmployeesEndpoint : Endpoint
{
    public static Endpoint Create(ModelElementsRegistry elementsRegistry) => new GetEmployeesEndpoint()
        .WithName("Get Employees")
        .WithMethod("GET")
        .WithPath("/employees")
        .WithResponseModel(elementsRegistry.GetElement<EmployeesResponse>());
}
