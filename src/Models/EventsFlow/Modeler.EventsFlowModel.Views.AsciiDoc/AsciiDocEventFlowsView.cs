namespace Modeler.EventsFlowModel.Views.AsciiDoc;

public class AsciiDocEventFlowsView
{
    public AsciiDocEventFlowsView(string id, Model model)
    {
        Id = id;
        Model = model;
    }

    public string Id { get; }

    public Model Model { get; }
}

public abstract class AsciiDocEventFlowsViewDefinition
{
}
