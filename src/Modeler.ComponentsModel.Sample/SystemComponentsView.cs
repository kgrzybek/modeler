using Modeler.ComponentsModel.Views.PlantUml;

namespace Modeler.ComponentsModel.Sample;

public class SystemComponentsView : ComponentsDiagramViewDefinition
{
    public const string Id = "SystemComponents";
    
    public static ComponentsDiagramView Create(SystemComponentsModel model)
    {
        var concepts = new List<Component>();

        concepts.Add(model.GetComponent<SystemComponent>());
        
        var view = new ComponentsDiagramView(Id, concepts);

        return view;
    }
}