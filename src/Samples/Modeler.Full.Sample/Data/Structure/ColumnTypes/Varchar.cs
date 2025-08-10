using Modeler.DataModel.Structure;

namespace Modeler.Full.Sample.Data.Structure.ColumnTypes;

public class Varchar : ColumnType
{
    public Varchar(int length) 
        : base($"VARCHAR({length})")
    {
    }
}