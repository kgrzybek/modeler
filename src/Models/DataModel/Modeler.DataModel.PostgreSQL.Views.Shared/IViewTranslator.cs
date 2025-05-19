using Modeler.DataModel.Relationships.Multiplicity;

namespace Modeler.DataModel.PostgreSQL.Views.Shared;

public interface IViewTranslator
{
    public string TranslateMultiplicity(RelationshipMultiplicity multiplicity);
}