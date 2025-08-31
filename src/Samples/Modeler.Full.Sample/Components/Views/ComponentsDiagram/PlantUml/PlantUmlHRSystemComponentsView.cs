using Modeler.Full.Sample.Components.ExternalSystems;
using Modeler.Full.Sample.Components.System;
using Modeler.Views.Components.ComponentsDiagram;

namespace Modeler.Full.Sample.Components.Views.ComponentsDiagram.PlantUml;

public class PlantUmlHRSystemComponentsView : PlantUmlComponentsDiagramView
{
    public PlantUmlHRSystemComponentsView(SystemComponentsModel model)
    {
        Components =
        [
            model.GetComponent<HRSystemBoundary>(),
            model.GetComponent<CRM>()
        ];
    }
}