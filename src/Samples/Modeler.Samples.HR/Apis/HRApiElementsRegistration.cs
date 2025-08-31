using Modeler.Samples.HR.Apis.ApiModels;
using Modeler.Samples.HR.Apis.Endpoints;

namespace Modeler.Samples.HR.Apis;

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