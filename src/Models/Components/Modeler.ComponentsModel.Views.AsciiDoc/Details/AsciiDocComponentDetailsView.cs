namespace Modeler.ComponentsModel.Views.AsciiDoc.Details;

public class AsciiDocComponentDetailsView
{
    public AsciiDocComponentDetailsView(string id, Component component)
    {
        Component = component;
        Id = id;
    }

    public Component Component { get; }
    
    public string Id { get; }
}

public abstract class AsciiDocComponentDetailsViewDefinition
{
    
}