using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Views.PlantUml.PlantUml;

namespace Modeler.ConceptualModel.Sample.TestViews;

public class OrganizationStructureView : PlantUmlViewFactory
{
    public static PlantUmlView Create()
    {
        var concepts = new List<VisibleEntity>();

        var model = OrganizationStructureConceptualModel.GetInstance();
        
        concepts.Add(new VisibleEntity(model.GetEntity<Employee>()));
        concepts.Add(new VisibleEntity(model.GetEntity<OrganizationUnit>()));
        concepts.Add(new VisibleEntity(model.GetEntity<Manager>()));
        
        var view = new PlantUmlView(concepts, "OrganizationStructure.puml");

        return view;
    }
}