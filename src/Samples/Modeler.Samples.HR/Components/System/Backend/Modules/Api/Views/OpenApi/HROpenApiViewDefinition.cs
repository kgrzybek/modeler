using Modeler.Models.Common.Elements;
using Modeler.Views.RestApi.OpenApi.Shared;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.OpenApi;

public class HROpenApiViewDefinition : OpenApiView
{
    public HROpenApiViewDefinition(ModelElementsRegistry elementsRegistry) : base(elementsRegistry.GetElement<HRRestApiComponent>())
    {
    }
}
