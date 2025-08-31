using Modeler.ComponentsModel;
using Models.Elements;

namespace Modeler.Views.Components.ComponentsDiagram;

public abstract class PlantUmlComponentsDiagramView : IView
{
    public List<IComponent> Components { get; protected init; } = [];
}