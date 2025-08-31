namespace Modeler.ComponentsModel;

public abstract record ComponentType
{
    protected ComponentType(string name)
    {
        Name = name;
    }

    public string Name { get; }
}