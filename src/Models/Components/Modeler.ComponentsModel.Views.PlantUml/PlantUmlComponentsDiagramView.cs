using Models.Elements;

namespace Modeler.ComponentsModel.Views.PlantUml;

public abstract class PlantUmlComponentsDiagramView : IView
{
    public List<IComponent> Components { get; protected init; } = [];
}