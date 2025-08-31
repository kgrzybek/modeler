using Modeler.ComponentsModel;
using Models.Elements;

namespace Modeler.Views.Components.Details.AsciiDoc;

public abstract class AsciiDocComponentDetailsView : IView
{
    protected AsciiDocComponentDetailsView(IComponent component)
    {
        Component = component;
    }
    public IComponent Component { get; }
}