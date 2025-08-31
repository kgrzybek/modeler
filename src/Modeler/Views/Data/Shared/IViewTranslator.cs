using Modeler.DataModel.Relationships.Multiplicity;

namespace Modeler.Views.Data.Shared;

public interface IViewTranslator
{
    public string TranslateMultiplicity(RelationshipMultiplicity multiplicity);
}