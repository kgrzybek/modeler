using Modeler.DataModel.Structure;

namespace Modeler.DataModel.Tests.Sample.ColumnTypes;

public class Timestamp : ColumnType
{
    public Timestamp() 
        : base("TIMESTAMP")
    {
    }
}