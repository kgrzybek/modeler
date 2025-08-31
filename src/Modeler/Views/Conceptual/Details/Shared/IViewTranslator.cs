using Modeler.Models.Conceptual.Relationships.Associations.Multiplicity;

namespace Modeler.Views.Conceptual.ConceptDetails.Shared;

public interface IViewTranslator
{
    public string TranslateMultiplicity(RelationshipMultiplicity multiplicity);
}