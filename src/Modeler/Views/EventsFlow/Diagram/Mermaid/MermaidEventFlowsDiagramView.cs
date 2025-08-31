using Modeler.Models.Common;
using Modeler.Models.EventsFlow;
using Modeler.Views.Common;

namespace Modeler.Views.EventsFlow.Diagram.Mermaid;

public abstract class MermaidEventFlowsDiagramView : IView
{
    public List<FlowElement> FlowElementsVisible { get; protected set; }
}