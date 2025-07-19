using Modeler.Full.Sample.Apis.Endpoints;
using Modeler.RestApiModel;
using Models.Elements;

namespace Modeler.Full.Sample.Apis;

public class HRRestApiModel : IApiModel
{
    private readonly List<Endpoint> _endpoints;

    public static HRRestApiModel Create(ModelElementsRegistry registry)
    {
        var endpoints = new List<Endpoint>
        {
            registry.GetElement<AddEmployeeEndpoint>(),
            registry.GetElement<GetEmployeesEndpoint>()
        };
        return new HRRestApiModel("HRRestApi", endpoints);
    }

    private HRRestApiModel(string name, List<Endpoint> endpoints)
    {
        Name = name;
        Id = ElementIdGenerator.GenerateElementId(this.GetType(), name);
        _endpoints = endpoints;
    }
    
    public List<Endpoint> GetEndpoints() => _endpoints;

    public List<ApiObjectModel> GetApiObjectModels()
    {
        var requests = _endpoints
            .Where(x => x.RequestModel != null)
            .Select(x => x.RequestModel).ToList();
        var responses = _endpoints
            .Where(x => x.ResponseModel != null)
            .Select(x => x.ResponseModel).ToList();
        
        requests.AddRange(responses);
        
        return requests.Distinct().ToList();
    }

    public string Name { get; }
    public string Id { get; }
}
