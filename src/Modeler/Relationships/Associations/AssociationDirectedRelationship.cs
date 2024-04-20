using Modeler.Relationships.Associations.Multiplicity;

namespace Modeler.Relationships.Associations;

public class AssociationDirectedRelationship
{
    public AssociationDirectedRelationship(string name, Entity from, RelationshipMultiplicity multiplicity, Entity to)
    {
        Name = name;
        From = from;
        To = to;
        Multiplicity = multiplicity;
    }

    public string Name { get; }
    
    public Entity From { get; }
    
    public Entity To { get; }
    
    public RelationshipMultiplicity Multiplicity { get; }
}