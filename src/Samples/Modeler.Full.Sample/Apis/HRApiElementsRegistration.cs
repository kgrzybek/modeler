using Modeler.Full.Sample.Apis.ApiModels;
using Modeler.Full.Sample.Apis.Endpoints;
using Modeler.RestApiModel.Sample.Models.ApiModels;

namespace Modeler.Full.Sample.Apis;

internal static class HRApiElementsRegistration
{
    internal static void RegisterHRApiElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(AddEmployeeRequest.Create());
        elementsRegistry.AddElement(EmployeeObjectModel.Create());
        elementsRegistry.AddElement(EmployeesResponse.Create());
        
        elementsRegistry.AddElement(AddEmployeeEndpoint.Create(elementsRegistry));
        elementsRegistry.AddElement(GetEmployeesEndpoint.Create(elementsRegistry));
        
        elementsRegistry.AddElement(HRRestApiModel.Create(elementsRegistry));
    }
}