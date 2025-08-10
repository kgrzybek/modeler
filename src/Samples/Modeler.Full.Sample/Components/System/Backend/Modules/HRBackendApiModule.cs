using Modeler.ComponentsModel;
using Modeler.Full.Sample.Apis;
using Modeler.Full.Sample.Components.Types;
using Modeler.RestApiModel;
using Models.Elements;

namespace Modeler.Full.Sample.Components.System.Backend.Modules;

public class HRBackendApiModule : Component, IApiProvider
{
    public static IElement Create(ElementsRegistry elementsRegistry)
    {
        return new HRBackendApiModule(elementsRegistry);
    }
    private HRBackendApiModule(ElementsRegistry elementsRegistry) : base("HR Backend Api", new ModuleComponentType())
    {
        ProvidedApi = elementsRegistry.GetElement<HRRestApiModel>();
    }

    public IApiModel ProvidedApi { get; }
}