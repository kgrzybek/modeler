using Modeler.ComponentsModel;
using Modeler.ComponentsModel.Views.PlantUml;
using Modeler.Full.Sample.Components.ExternalSystems;
using Modeler.Full.Sample.Components.System;

namespace Modeler.Full.Sample.Components.Views;

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