namespace Modeler.DataModel.Structure;

public class View : StructureElement
{
    public View()
    {
        var name = this.GetType().Name;
        this.Name = name.Substring(0, name.Length - 7);
        Columns = new List<ViewColumn>();
    }
    
    public View WithName(
        string name)
    {
        this.Name = name;

        return this;
    }
    
    public View WithColumn(
        string name,
        ColumnType type)
    {
        Columns.Add(ViewColumn.Create(name, type));

        return this;
    }
    
    public List<ViewColumn> Columns { get; protected init; }
}