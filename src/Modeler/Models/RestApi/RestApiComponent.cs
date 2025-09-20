using Modeler.Models.Components;

namespace Modeler.Models.RestApi;

public class RestApiComponent : Component, IApiModel
{
    protected List<Endpoint> Endpoints { get; set; }

    protected RestApiComponent(string name, ComponentType type) : base(name, type)
    {
    }

    public List<Endpoint> GetEndpoints() => Endpoints;

    public List<ApiObjectModel> GetApiObjectModels()
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