using Modeler.Models.Data.Structure;

namespace Modeler.Samples.HR.Components.System.Database.Structure.ColumnTypes;

public class Interval : ColumnType
{
    public Interval() 
        : base("INTERVAL")
    {
    }
}