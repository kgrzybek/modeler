using Modeler.Models.Components;
using Modeler.Views.Common;

namespace Modeler.Views.Components.Diagram;

public abstract class PlantUmlComponentsDiagramView : IView
{
    public List<VisibleComponent> VisibleComponents { get; protected init; } = [];
    
    public List<IComponent> HiddenComponents { get; protected init; } = [];
    
    public List<HiddenRelationship>  HiddenRelationships { get; protected init; } = new List<HiddenRelationship>();
}