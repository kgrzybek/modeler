namespace Modeler.DataModel.Structure;

public abstract class Column
{
    protected Column(
        string name,
        ColumnType type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; }
    
    public ColumnType Type { get; }
}