using Modeler.Models.Common.Elements;
using Modeler.Models.RestApi;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.Endpoints;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api;

public class HRRestApiComponent : RestApiComponent
{
    public HRRestApiComponent(ModelElementsRegistry elementsRegistry) : base("HR REST API", new RestApiComponentType())
    {
        Endpoints =
        [
            elementsRegistry.GetElement<AddEmployeeEndpoint>(),
            elementsRegistry.GetElement<GetEmployeesEndpoint>()
        ];
    }
}
