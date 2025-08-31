using Modeler.Models.Common.Elements;

namespace Modeler.Models.Components;

public interface IComponent : IElement
{
    public ComponentType Type { get; }
}