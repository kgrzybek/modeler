namespace Modeler.EventsFlowModel.Views.Mermaid;

public interface IMermaidEventsFlowViewsOutput<T>
{
    public void Execute(List<MermaidEventsFlowViewsOutputItem<T>> views);
}