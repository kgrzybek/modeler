using Modeler.ConceptualModel.Relationships.Associations.Multiplicity;

namespace Modeler.ConceptualModel.Relationships.Associations;

public class AssociationDirectedRelationship
{
    public AssociationDirectedRelationship(
        string name,
        Entity from,
        RelationshipMultiplicity multiplicity,
        Entity to,
        string? description = null)
    {
        Name = name;
        From = from;
        To = to;
        Description = description;
        Multiplicity = multiplicity;
    }

    public string Name { get; }
    
    public Entity From { get; }
    
    public Entity To { get; }
    
    public RelationshipMultiplicity Multiplicity { get; }
    
    public string? Description { get; }
}