namespace Modeler.ConceptualModel.Views.Shared;

public interface IViewsOutput
{
    public void Execute(List<ViewOutputItem> views);
}

public record ViewOutputItem(ClassDiagramView View, string Content);