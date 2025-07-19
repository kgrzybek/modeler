using Modeler.Full.Sample.Apis.ApiModels;
using Modeler.RestApiModel;
using Modeler.RestApiModel.Sample.Models.ApiModels;
using Models.Elements;

namespace Modeler.Full.Sample.Apis.Endpoints;

public class AddEmployeeEndpoint : Endpoint
{
    public static Endpoint Create(ModelElementsRegistry elementsRegistry) => new AddEmployeeEndpoint()
        .WithName("Add Employee")
        .WithMethod("POST")
        .WithPath("/employees")
        .WithRequestModel(elementsRegistry.GetElement<AddEmployeeRequest>())
        .WithResponseModel(elementsRegistry.GetElement<EmployeeObjectModel>());
}
