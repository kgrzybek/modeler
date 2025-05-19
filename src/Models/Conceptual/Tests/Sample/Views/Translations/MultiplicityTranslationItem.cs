using Modeler.ConceptualModel.Relationships.Associations.Multiplicity;

namespace Modeler.ConceptualModel.Sample.Views.Translations;

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