namespace Modeler.DataModel.Structure;

public class TableColumn : Column
{
    public bool IsNullable { get; set; }
    
    public bool IsPrimaryKey { get; set; }
    
    public string? Description { get; }
    
    private TableColumn(string name, ColumnType type, bool isNull, bool isPrimaryKey, string? description) 
        : base(name, type)
    {
        IsNullable = isNull;
        IsPrimaryKey = isPrimaryKey;
        Description = description;
    }
    
    public static TableColumn Create(
        string name,
        ColumnType type,
        bool isNull,
        bool isPrimaryKey = false,
        string? description = null)
    {
        return new TableColumn(name, type, isNull, isPrimaryKey, description);
    }
}