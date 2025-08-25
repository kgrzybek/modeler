using Modeler.ComponentsModel.Sample.Components;
using Modeler.ComponentsModel.Sample.Components.ExternalSystems;
using Modeler.ComponentsModel.Sample.Components.HRSystem;
using Modeler.ComponentsModel.Views.PlantUml;

namespace Modeler.ComponentsModel.Sample.Views;

public class SystemComponentsView
{
    public const string Id = "SystemComponents";
    
    public static ComponentsDiagramView Create(SystemComponentsModel model)
    {
        var concepts = new List<IComponent>();

        concepts.Add(model.GetComponent<HRSystemBoundary>());
        concepts.Add(model.GetComponent<CRM>());
        
        var view = new ComponentsDiagramView(Id, concepts);

        return view;
    }
}