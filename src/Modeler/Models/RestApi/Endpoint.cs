using Modeler.Models.Common.Elements;

namespace Modeler.Models.RestApi;

public abstract class Endpoint : IElement
{
    protected Endpoint WithName(string name)
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

    public Endpoint WithRequestModel(IApiObjectModel objectModel)
    {
        RequestModel = objectModel;
        return this;
    }

    public Endpoint WithResponseModel(ApiObjectModel objectModel)
    {
        ResponseModel = objectModel;
        return this;
    }

    public string Name { get; private set; } = "Undefined";

    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string Method { get; private set; } = "GET";

    public string Path { get; private set; } = "/";

    public IApiObjectModel? RequestModel { get; private set; }

    public IApiObjectModel? ResponseModel { get; private set; }
}
