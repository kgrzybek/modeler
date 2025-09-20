using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.System;
using Modeler.Views.Components.Diagram;

namespace Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;

public class PlantUmlHRSystemComponentsView : PlantUmlComponentsDiagramView
{
    public PlantUmlHRSystemComponentsView(SystemComponentsModel model)
    {
        VisibleComponents =
        [
            new VisibleComponent(model.GetComponent<HRSystem>(), nestedComponentsLevel: 1),
            new VisibleComponent(model.GetComponent<CRM>())
        ];
    }
}