using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.System;
using Modeler.Views.Components.ComponentsDiagram;

namespace Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;

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