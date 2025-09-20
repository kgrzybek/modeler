using Modeler.Models.Data.Structure;

namespace Modeler.Samples.HR.Components.System.Database.Structure.ColumnTypes;

public class Timestamp : ColumnType
{
    public Timestamp() 
        : base("TIMESTAMP")
    {
    }
}