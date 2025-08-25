using Modeler.ConceptualModel.Views.Shared;
using Modeler.Full.Sample.Conceptual.Concepts;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views;

public class OrganizationStructureView
{
    public const string Id = "OrganizationStructure";
    
    public static ClassDiagramView Create(OrganizationStructureConceptualModel model)
    {
        var concepts = new List<VisibleEntity>();
        
        concepts.Add(new VisibleEntity(model.GetEntity<Employee>()));
        concepts.Add(new VisibleEntity(model.GetEntity<OrganizationUnit>()));
        concepts.Add(new VisibleEntity(model.GetEntity<Manager>()));
        
        var view = new ClassDiagramView(Id, concepts);

        return view;
    }
}