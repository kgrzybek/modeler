using Modeler.Models.Common.Elements;
using Modeler.Models.Components;
using Modeler.Models.RestApi;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.System.Backend.Modules;

public class HRBackendApiModule : Component, IApiProvider
{
    public static IElement Create(ElementsRegistry elementsRegistry)
    {
        return new HRBackendApiModule(elementsRegistry);
    }
    private HRBackendApiModule(ElementsRegistry elementsRegistry) : base("HR Backend Api", new ModuleComponentType())
    {
        ProvidedApi = elementsRegistry.GetElement<HRRestApiComponent>();
    }

    public IApiModel ProvidedApi { get; }
}