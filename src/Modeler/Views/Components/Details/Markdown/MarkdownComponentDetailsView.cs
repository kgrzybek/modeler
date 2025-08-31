using Models.Elements;

namespace Modeler.ComponentsModel.Views.Markdown.Details;

public abstract class MarkdownComponentDetailsView : IView
{
    protected MarkdownComponentDetailsView(IComponent component)
    {
        Component = component;
    }
    public IComponent Component { get; }
}
