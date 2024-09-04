using Modeler.DataModel.Structure;

namespace Modeler.DataModel.Tests.Sample.ColumnTypes;

public class Interval : ColumnType
{
    public Interval() 
        : base("INTERVAL")
    {
    }
}