using Modeler.DataModel.Relationships.Multiplicity;
using Modeler.DataModel.Structure;

namespace Modeler.DataModel.Relationships;

public class StructureElementRelationship
{
    public StructureElementRelationship(
        Table from,
        string fromColumnName,
        RelationshipMultiplicity fromMultiplicity,
        Table to,
        string toColumnName,
        RelationshipMultiplicity toMultiplicity)
    {
        if (from.Columns.All(x => x.Name != fromColumnName))
        {
            throw new Exception($"Element {from.Name} does not have {fromColumnName} column.");
        }
        
        if (to.Columns.All(x => x.Name != toColumnName))
        {
            throw new Exception($"Element {to.Name} does not have {toColumnName} column.");
        }
        
        From = from;
        FromColumnName = fromColumnName;
        To = to;
        ToColumnName = toColumnName;
        ToMultiplicity = toMultiplicity;
        FromMultiplicity = fromMultiplicity;
    }

    public Table From { get; }
    
    public string FromColumnName { get; }
    
    public RelationshipMultiplicity FromMultiplicity { get; }
    
    public Table To { get; }
    
    public string ToColumnName { get; }
    
    public RelationshipMultiplicity ToMultiplicity { get; }

    public string GetRelationshipName()
    {
        return FromColumnName == ToColumnName ? 
            $"{FromColumnName}" : 
            $"{From.Name}.{FromColumnName} = {To.Name}.{ToColumnName}";
    }
}