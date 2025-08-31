using Models.Elements;

namespace Modeler.RestApiModel;

public class Endpoint : IElement
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

    public Endpoint WithRequestModel(ApiObjectModel objectModel)
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

    public ApiObjectModel? RequestModel { get; private set; }

    public ApiObjectModel? ResponseModel { get; private set; }
}
