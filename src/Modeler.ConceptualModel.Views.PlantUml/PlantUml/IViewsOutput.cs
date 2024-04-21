namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

public interface IViewsOutput
{
    public void Execute(List<ViewOutputItem> views);
}

public record ViewOutputItem(PlantUmlView View, string Content);