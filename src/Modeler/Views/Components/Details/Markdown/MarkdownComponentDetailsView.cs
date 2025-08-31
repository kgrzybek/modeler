using Modeler.Models.Common;
using Modeler.Models.Components;
using Modeler.Views.Common;

namespace Modeler.Views.Components.Details.Markdown;

public abstract class MarkdownComponentDetailsView : IView
{
    protected MarkdownComponentDetailsView(IComponent component)
    {
        Component = component;
    }
    public IComponent Component { get; }
}
