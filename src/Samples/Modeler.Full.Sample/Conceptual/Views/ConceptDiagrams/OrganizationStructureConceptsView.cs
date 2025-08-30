using Modeler.ConceptualModel.Views.Shared;
using Modeler.Full.Sample.Conceptual.Concepts;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDiagrams;

public class OrganizationStructureConceptsView : ConceptsClassDiagramView
{
    public OrganizationStructureConceptsView(OrganizationStructureConceptualModel model)
    {
        VisibleEntities =
        [
            new VisibleEntity(model.GetEntity<Employee>()),
            new VisibleEntity(model.GetEntity<OrganizationUnit>()),
            new VisibleEntity(model.GetEntity<Manager>())
        ];
    }
}