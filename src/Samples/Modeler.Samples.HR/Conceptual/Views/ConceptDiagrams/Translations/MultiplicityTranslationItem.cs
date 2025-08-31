using Modeler.Models.Conceptual.Relationships.Associations.Multiplicity;

namespace Modeler.Samples.HR.Conceptual.Views.Translations;

public class MultiplicityTranslationItem
{
    public MultiplicityTranslationItem(RelationshipMultiplicity multiplicity, string name)
    {
        Multiplicity = multiplicity;
        Name = name;
    }

    public RelationshipMultiplicity Multiplicity { get; }
    
    public string Name { get; }
}