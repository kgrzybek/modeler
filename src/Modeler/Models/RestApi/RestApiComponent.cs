using Modeler.Models.Components;

namespace Modeler.Models.RestApi;

public abstract class RestApiComponent : Component, IApiModel
{
    protected List<Endpoint> Endpoints { get; init; }

    protected RestApiComponent(string name, ComponentType type) : base(name, type)
    {
        Endpoints = [];
    }

    public List<Endpoint> GetEndpoints() => Endpoints;

    public List<IApiObjectModel> GetApiObjectModels()
    {
        var requests = Endpoints
            .Where(x => x.RequestModel != null)
            .Select(x => x.RequestModel).ToList();
        var responses = Endpoints
            .Where(x => x.ResponseModel != null)
            .Select(x => x.ResponseModel).ToList();
        
        requests.AddRange(responses);
        
        return requests.Distinct().ToList();
    }
}