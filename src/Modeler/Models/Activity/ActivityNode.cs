namespace Modeler.Models.Activity;

public abstract class ActivityNode
{
    protected ActivityNode(string name)
    {
        Name = name;
        Id = string.Empty;
    }

    public string Name { get; }

    public string Id { get; private set; }

    internal void SetId(string id)
    {
        Id = id;
    }
}
