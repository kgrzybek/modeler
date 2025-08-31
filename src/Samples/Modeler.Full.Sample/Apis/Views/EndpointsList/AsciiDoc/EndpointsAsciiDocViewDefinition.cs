using Modeler.RestApiModel.Views.AsciiDoc;
using Models.Elements;

namespace Modeler.Full.Sample.Apis.Views.AsciiDoc;

public class EndpointsAsciiDocViewDefinition : AsciiDocEndpointsView
{
    public EndpointsAsciiDocViewDefinition(ModelElementsRegistry elementsRegistry) : base(elementsRegistry.GetElement<HRRestApiModel>())
    {
    }
}
