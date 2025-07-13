namespace Modeler.ComponentsModel.Views.AsciiDoc.Details;

public class AsciiDocComponentDetailsView
{
    public AsciiDocComponentDetailsView(string id, IComponent component)
    {
        Component = component;
        Id = id;
    }

    public IComponent Component { get; }
    
    public string Id { get; }
}

public abstract class AsciiDocComponentDetailsViewDefinition
{
    
}