using Modeler.DataModel.Relationships.Multiplicity;

namespace Modeler.Full.Sample.Data.Views.Translations;

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