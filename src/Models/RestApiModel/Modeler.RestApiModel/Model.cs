using System.Reflection;
using Models.Elements;

namespace Modeler.RestApiModel;

public abstract class Model
{
    protected readonly List<Endpoint> Endpoints;
    private readonly List<ApiObjectModel> _apiObjectModels;
    private readonly List<IApiModel> _apis;

    protected Model(ModelElementsRegistry elementsRegistry)
    {
        Endpoints = elementsRegistry.GetElements<Endpoint>();
        _apiObjectModels = elementsRegistry.GetElements<ApiObjectModel>();
        _apis = elementsRegistry.GetElements<IApiModel>();
    }

    public List<Endpoint> GetEndpoints() => Endpoints.ToList();
    public List<ApiObjectModel> GetApiObjectModels() => _apiObjectModels.ToList();    
    public List<IApiModel> GetApis() => _apis.ToList();

}
