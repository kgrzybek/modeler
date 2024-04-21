using Modeler.Relationships.Associations.Multiplicity;

namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

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