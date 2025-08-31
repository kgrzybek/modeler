using Models.Elements;

namespace Modeler.ComponentsModel;

public abstract class Component : Element, IComponent
{
    protected Component(string name, ComponentType type) : base(name)
    {
        this.Type = type;
    }
    
    public ComponentType Type { get; }
}