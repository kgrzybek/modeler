using Modeler.Models.Common.Elements;

namespace Modeler.Models.Conceptual;

public abstract class Concept : IElement
{
    public string Name { get; protected set; } = "Undefined";
    public string Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        return obj?.GetType() == this.GetType();
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }

    public override string ToString()
    {
        return this.GetType().Name;
    }
}