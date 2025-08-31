using Modeler.ComponentsModel;
using Models.Elements;

namespace Modeler.Views.Components.Details.Markdown;

public abstract class MarkdownComponentDetailsView : IView
{
    protected MarkdownComponentDetailsView(IComponent component)
    {
        Component = component;
    }
    public IComponent Component { get; }
}
