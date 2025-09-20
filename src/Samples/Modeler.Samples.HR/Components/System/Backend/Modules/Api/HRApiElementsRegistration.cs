using Modeler.Samples.HR.Components.System.Backend.Modules.Api.ApiModels;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.Endpoints;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api;

internal static class HRApiElementsRegistration
{
    internal static void RegisterHRApiElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(AddEmployeeRequest.Create());
        elementsRegistry.AddElement(EmployeeObjectModel.Create());
        elementsRegistry.AddElement(EmployeesResponse.Create());
        
        elementsRegistry.AddElement(AddEmployeeEndpoint.Create(elementsRegistry));
        elementsRegistry.AddElement(GetEmployeesEndpoint.Create(elementsRegistry));
        
        elementsRegistry.AddElement(new HRRestApiComponent(elementsRegistry));
    }
}