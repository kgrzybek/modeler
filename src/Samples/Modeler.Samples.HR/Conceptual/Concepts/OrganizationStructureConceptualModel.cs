using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Conceptual;

namespace Modeler.Samples.HR.Conceptual.Concepts;

public class OrganizationStructureConceptualModel : Model
{
    public OrganizationStructureConceptualModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        OrganizationStructureRelationshipsModel.Create(this);
    }
}