using Modeler.Relationships.Associations.Multiplicity;

namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

public interface IViewTranslator
{
    public string TranslateMultiplicity(RelationshipMultiplicity multiplicity);
}