using Modeler.ConceptualModel.Relationships.Associations.Multiplicity;

namespace Modeler.ConceptualModel.Views.Shared;

public interface IViewTranslator
{
    public string TranslateMultiplicity(RelationshipMultiplicity multiplicity);
}