using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Views.RestApi.EndpointsList.AsciiDoc;

namespace Modeler.Samples.HR.Apis.Views.AsciiDoc;

public class EndpointsAsciiDocViewDefinition : AsciiDocEndpointsView
{
    public EndpointsAsciiDocViewDefinition(ModelElementsRegistry elementsRegistry) : base(elementsRegistry.GetElement<HRRestApiModel>())
    {
    }
}
