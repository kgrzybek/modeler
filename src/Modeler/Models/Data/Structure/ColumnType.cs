namespace Modeler.DataModel.Structure;

public abstract class ColumnType
{
    public string Name { get; }

    protected ColumnType(string name)
    {
        Name = name;
    }
}