namespace Modeler.EventsFlowModel.Views.Mermaid;

public class MermaidEventFlowsView
{
    public MermaidEventFlowsView(
        string id,
        List<FlowElement> flowElementsVisible)
    {
        FlowElementsVisible = flowElementsVisible;
        Id = id;
    }

    public List<FlowElement> FlowElementsVisible { get; }
    
    public string Id { get; }
}