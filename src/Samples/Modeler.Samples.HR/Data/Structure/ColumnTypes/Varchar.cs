using Modeler.Models.Data.Structure;

namespace Modeler.Samples.HR.Data.Structure.ColumnTypes;

public class Varchar : ColumnType
{
    public Varchar(int length) 
        : base($"VARCHAR({length})")
    {
    }
}