using Models.Elements;

namespace Modeler.ComponentsModel;

public interface IComponent : IElement
{
    public ComponentType Type { get; }
}