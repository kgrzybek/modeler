using System.Reflection;

namespace Modeler.RestApiModel;

public abstract class Model
{
    private readonly List<Endpoint> _endpoints;
    private readonly List<ApiModel> _apiModels;

    protected Model()
    {
        _endpoints = new List<Endpoint>();
        _apiModels = new List<ApiModel>();
        RegisterApiModels();
        RegisterEndpoints();
    }

    private void RegisterEndpoints()
    {
        var assembly = Assembly.GetAssembly(GetType())!;
        var types = assembly.GetTypes().Where(t => typeof(Endpoint).IsAssignableFrom(t));
        foreach (var type in types)
        {
            var method = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (method != null)
            {
                var endpoint = method.Invoke(null, null);
                _endpoints.Add((Endpoint)endpoint!);
            }
        }
    }

    private void RegisterApiModels()
    {
        var assembly = Assembly.GetAssembly(GetType())!;
        var types = assembly.GetTypes().Where(t => typeof(ApiModel).IsAssignableFrom(t));
        foreach (var type in types)
        {
            var method = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (method != null)
            {
                var model = method.Invoke(null, null);
                _apiModels.Add((ApiModel)model!);
            }
        }
    }

    public void AddEndpoint(Endpoint endpoint) => _endpoints.Add(endpoint);

    public void AddApiModel(ApiModel model) => _apiModels.Add(model);

    public T GetEndpoint<T>() where T : Endpoint => _endpoints.OfType<T>().Single();

    public T GetApiModel<T>() where T : ApiModel => _apiModels.OfType<T>().Single();

    public List<Endpoint> GetEndpoints() => _endpoints.ToList();

    public List<ApiModel> GetApiModels() => _apiModels.ToList();
}
