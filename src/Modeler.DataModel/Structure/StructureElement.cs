using Modeler.DataModel.Schemas;

namespace Modeler.DataModel.Structure;

public abstract class StructureElement
{
    public string Name { get; set; } = string.Empty;

    public Schema Schema { get; set; } = new NoSchema();
    
    public List<Column> Columns { get; protected init; } = new List<Column>();
    
    protected T GetColumn<T>(string name) where T: Column
    {
        return Columns.OfType<T>().Single(x => x.Name == name);
    }
}