using Modeler.DataModel.Schemas;

namespace Modeler.DataModel.Structure;

public abstract class Table : StructureElement
{
    public Table InSchema(Schema schema)
    {
        this.Schema = schema;

        return this;
    }
    
    public Table WithName(
        string name)
    {
        this.Name = name;

        return this;
    }
    
    public Table WithColumn(
        string name,
        ColumnType type,
        bool isNullable,
        bool isPrimaryKey = false,
        string? description = null)
    {
        Columns.Add(TableColumn.Create(name, type, isNullable, isPrimaryKey, description));

        return this;
    }
    
    public Table WithColumnAsPrimaryKey(
        string name,
        ColumnType type,
        string? description = null)
    {
        Columns.Add(TableColumn.Create(name, type, false, true, description));

        return this;
    }
    
    public TableColumn GetColumn(string name)
    {
        return Columns.OfType<TableColumn>().Single(x => x.Name == name);
    }
}