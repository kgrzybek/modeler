namespace Modeler.ConceptualModel;

public abstract class Concept
{
    public string Name { get; protected set; } = "Undefined";

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