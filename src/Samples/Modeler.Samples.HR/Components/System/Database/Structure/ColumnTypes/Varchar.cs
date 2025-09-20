using Modeler.Models.Data.Structure;

namespace Modeler.Samples.HR.Components.System.Database.Structure.ColumnTypes;

public class Varchar : ColumnType
{
    public Varchar(int length) 
        : base($"VARCHAR({length})")
    {
    }
}