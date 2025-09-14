using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.System;
using Modeler.Views.Components.Diagram;

namespace Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;

public class PlantUmlHRSystemModulesView : PlantUmlComponentsDiagramView
{
    public PlantUmlHRSystemModulesView(SystemComponentsModel model)
    {
        VisibleComponents =
        [
            new VisibleComponent(model.GetComponent<HRSystemBoundary>(), nestedComponentsLevel: 3),
            new VisibleComponent(model.GetComponent<CRM>())
        ];
    }
}