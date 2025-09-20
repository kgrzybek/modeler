using Modeler.Models.Common.Elements;
using Modeler.Views.RestApi.EndpointsList.AsciiDoc;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.EndpointsList.AsciiDoc;

public class EndpointsAsciiDocViewDefinition : AsciiDocEndpointsView
{
    public EndpointsAsciiDocViewDefinition(ModelElementsRegistry elementsRegistry) : base(elementsRegistry.GetElement<HRRestApiComponent>())
    {
    }
}
