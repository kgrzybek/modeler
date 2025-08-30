using Models.Elements;

namespace Modeler.ComponentsModel.Views.AsciiDoc.Details;

public abstract class AsciiDocComponentDetailsView : IView
{
    protected AsciiDocComponentDetailsView(IComponent component)
    {
        Component = component;
    }
    public IComponent Component { get; }
}