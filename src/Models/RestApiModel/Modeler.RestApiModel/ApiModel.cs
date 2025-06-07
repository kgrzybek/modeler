namespace Modeler.RestApiModel;

public abstract class ApiModel
{
    protected ApiModel WithName(string name)
    {
        Name = name;
        Id = name.Replace(" ", "_").ToLower();
        return this;
    }

    protected ApiModel WithAttribute(string name, string type, bool required)
    {
        Attributes.Add(new ApiModelAttribute(name, type, required));
        return this;
    }

    public string Name { get; private set; } = "Undefined";

    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public List<ApiModelAttribute> Attributes { get; } = new();
}
