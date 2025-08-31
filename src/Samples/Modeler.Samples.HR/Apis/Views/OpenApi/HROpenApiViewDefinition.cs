using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Views.RestApi.OpenApi.Shared;

namespace Modeler.Samples.HR.Apis.Views.OpenApi;

public class HROpenApiViewDefinition : OpenApiView
{
    public HROpenApiViewDefinition(ModelElementsRegistry elementsRegistry) : base(elementsRegistry.GetElement<HRRestApiModel>())
    {
    }
}
