using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.RestApi;
using Modeler.Samples.HR.Apis.ApiModels;

namespace Modeler.Samples.HR.Apis.Endpoints;

public class AddEmployeeEndpoint : Endpoint
{
    public static Endpoint Create(ModelElementsRegistry elementsRegistry) => new AddEmployeeEndpoint()
        .WithName("Add Employee")
        .WithMethod("POST")
        .WithPath("/employees")
        .WithRequestModel(elementsRegistry.GetElement<AddEmployeeRequest>())
        .WithResponseModel(elementsRegistry.GetElement<EmployeeObjectModel>());
}
