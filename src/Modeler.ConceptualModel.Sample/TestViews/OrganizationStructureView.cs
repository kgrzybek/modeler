using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.ConceptualModel.Sample.TestViews;

public class OrganizationStructureView : ClassDiagramViewDefinition
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