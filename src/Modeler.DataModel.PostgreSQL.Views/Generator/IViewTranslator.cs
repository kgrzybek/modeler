using Modeler.DataModel.Relationships.Multiplicity;

namespace Modeler.DataModel.PostgreSQL.Views.Generator;

public interface IViewTranslator
{
    public string TranslateMultiplicity(RelationshipMultiplicity multiplicity);
}