using Modeler.EventsFlowModel;
using Models.Elements;

namespace Modeler.Views.EventsFlow.Diagram.Mermaid;

public abstract class MermaidEventFlowsDiagramView : IView
{
    public List<FlowElement> FlowElementsVisible { get; protected set; }
}