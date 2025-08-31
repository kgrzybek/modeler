namespace Modeler.Models.Data.Structure;

public class ViewColumn : Column
{
    private ViewColumn(string name, ColumnType type) 
        : base(name, type)
    {
    }
    
    public static ViewColumn Create(string name, ColumnType type)
    {
        return new ViewColumn(name, type);
    }
}