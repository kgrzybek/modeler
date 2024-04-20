namespace Modeler;

public abstract class Concept
{
    protected Concept(string name)
    {
        Name = name;
    }

    protected Concept()
    {
    }

    public string Name { get; protected set; }

    public override bool Equals(object? obj)
    {
        return obj?.GetType() == this.GetType();
    }

    protected bool Equals(Concept other)
    {
        return other?.GetType() == this.GetType();
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