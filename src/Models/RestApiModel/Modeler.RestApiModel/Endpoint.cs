namespace Modeler.RestApiModel;

public class Endpoint
{
    public Endpoint WithName(string name)
    {
        Name = name;
        Id = name.Replace(" ", "_").ToLower();
        return this;
    }

    public Endpoint WithMethod(string method)
    {
        Method = method;
        return this;
    }

    public Endpoint WithPath(string path)
    {
        Path = path;
        return this;
    }

    public Endpoint WithRequestModel(ApiModel model)
    {
        RequestModel = model;
        return this;
    }

    public Endpoint WithResponseModel(ApiModel model)
    {
        ResponseModel = model;
        return this;
    }

    public string Name { get; private set; } = "Undefined";

    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string Method { get; private set; } = "GET";

    public string Path { get; private set; } = "/";

    public ApiModel? RequestModel { get; private set; }

    public ApiModel? ResponseModel { get; private set; }
}
