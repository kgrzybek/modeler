namespace Modeler.ComponentsModel;

public abstract class Component
{
    public Component(string name)
    {
        SubComponents = new List<Component>();
        Name = name;
    }
    public string Name { get; set; }
    
    public ComponentType Type { get; set; }
    
    public List<Component> SubComponents { get; set; }
    
    protected Component WithName(
        string name)
    {
        this.Name = name;

        return this;
    }

    public List<Component> GetAll()
    {
        var allComponents = new List<Component>();
        foreach (var subComponent in SubComponents)
        {
            allComponents.Add(subComponent);
            allComponents.AddRange(subComponent.GetAll());
        }

        return allComponents;
    }
}