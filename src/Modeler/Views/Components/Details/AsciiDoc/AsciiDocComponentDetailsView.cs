using Modeler.Models.Common;
using Modeler.Models.Components;
using Modeler.Views.Common;

namespace Modeler.Views.Components.Details.AsciiDoc;

public abstract class AsciiDocComponentDetailsView : IView
{
    protected AsciiDocComponentDetailsView(IComponent component)
    {
        Component = component;
    }
    public IComponent Component { get; }
}