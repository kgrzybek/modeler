using Modeler.Views.RestApi.OpenApi.Shared;
using Models.Elements;

namespace Modeler.Full.Sample.Apis.Views.OpenApi;

public class HROpenApiViewDefinition : OpenApiView
{
    public HROpenApiViewDefinition(ModelElementsRegistry elementsRegistry) : base(elementsRegistry.GetElement<HRRestApiModel>())
    {
    }
}
