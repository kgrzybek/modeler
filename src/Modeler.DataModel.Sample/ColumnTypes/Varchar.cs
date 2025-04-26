using Modeler.DataModel.Structure;

namespace Modeler.DataModel.Sample.ColumnTypes;

public class Varchar : ColumnType
{
    public Varchar(int length) 
        : base($"VARCHAR({length})")
    {
    }
}