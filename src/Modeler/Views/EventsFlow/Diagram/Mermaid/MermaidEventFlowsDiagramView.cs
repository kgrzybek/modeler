using Models.Elements;

namespace Modeler.EventsFlowModel.Views.Mermaid;

public abstract class MermaidEventFlowsDiagramView : IView
{
    public List<FlowElement> FlowElementsVisible { get; protected set; }
}