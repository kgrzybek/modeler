using Modeler.Relationships.Associations.Multiplicity;

namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

public class MultiplicityTranslator
{
    private readonly List<MultiplicityTranslationItem> _items;

    public MultiplicityTranslator()
    {
        _items = new List<MultiplicityTranslationItem>();
    }

    public void AddTranslation(RelationshipMultiplicity multiplicity, string name)
    {
        _items.Add(new MultiplicityTranslationItem(multiplicity, name));
    }

    public string Translate(RelationshipMultiplicity multiplicity)
    {
        var item = _items.SingleOrDefault(x => x.Multiplicity.GetType() == multiplicity.GetType());

        if (item == null)
        {
            throw new ArgumentException("No translation");
        }
        
        return item.Name;
    }
}

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