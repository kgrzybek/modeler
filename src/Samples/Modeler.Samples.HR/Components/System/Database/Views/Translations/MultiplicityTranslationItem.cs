using Modeler.Models.Data.Relationships.Multiplicity;

namespace Modeler.Samples.HR.Components.System.Database.Views.Translations;

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