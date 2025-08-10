using Modeler.ConceptualModel;
using Models.Elements;

namespace Modeler.Full.Sample.Conceptual.Concepts;

public class OrganizationStructureConceptualModel : Model
{
    public OrganizationStructureConceptualModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        OrganizationStructureRelationshipsModel.Create(this);
    }
}