using Modeler.Models.Common;
using Modeler.Models.Components;
using Modeler.Views.Common;

namespace Modeler.Views.Components.ComponentsDiagram;

public abstract class PlantUmlComponentsDiagramView : IView
{
    public List<IComponent> Components { get; protected init; } = [];
}