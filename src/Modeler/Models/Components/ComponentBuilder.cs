namespace Modeler.Models.Components;

public class ComponentBuilder
{
    private readonly Component _node;

    private ComponentBuilder(Component component)
    {
        _node = component;
    }

    public static ComponentBuilder Create(Component component)
    {
        return new ComponentBuilder(component);
    }

    public ComponentBuilder AddChild(Component component, Action<ComponentBuilder>? childBuilderAction = null)
    {
        var childBuilder = new ComponentBuilder(component);
       
        childBuilderAction?.Invoke(childBuilder);
        
        return this;
    }

    public Component Build()
    {
        return _node;
    }
}