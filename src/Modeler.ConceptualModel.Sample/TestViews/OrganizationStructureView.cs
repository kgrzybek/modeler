using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Views.PlantUml.PlantUml;

namespace Modeler.ConceptualModel.Sample.TestViews;

public class OrganizationStructureView : PlantUmlViewFactory
{
    public const string Id = "OrganizationStructure";
    
    public static PlantUmlView Create(OrganizationStructureConceptualModel model)
    {
        var concepts = new List<VisibleEntity>();
        
        concepts.Add(new VisibleEntity(model.GetEntity<Employee>()));
        concepts.Add(new VisibleEntity(model.GetEntity<OrganizationUnit>()));
        concepts.Add(new VisibleEntity(model.GetEntity<Manager>()));
        
        var view = new PlantUmlView(Id, concepts);

        return view;
    }
}