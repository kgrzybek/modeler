using Modeler.ConceptualModel.Views.Shared;
using Modeler.Relationships.Associations.Multiplicity;

namespace Modeler.ConceptualModel.Sample.TestViews.Translations;

public class ViewTranslator : IViewTranslator
{
    private readonly List<MultiplicityTranslationItem> _items;

    public ViewTranslator()
    {
        _items = new List<MultiplicityTranslationItem>();
        AddTranslation(new One(), "1");
        AddTranslation(new ZeroOrMany(), "0..*");
    }

    private void AddTranslation(RelationshipMultiplicity multiplicity, string name)
    {
        _items.Add(new MultiplicityTranslationItem(multiplicity, name));
    }

    public string TranslateMultiplicity(RelationshipMultiplicity multiplicity)
    {
        var item = _items.SingleOrDefault(x => x.Multiplicity.GetType() == multiplicity.GetType());

        if (item == null)
        {
            throw new ArgumentException("No translation");
        }
        
        return item.Name;
    }
}