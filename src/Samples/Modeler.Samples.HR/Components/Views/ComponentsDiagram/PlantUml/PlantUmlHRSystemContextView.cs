using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.System;
using Modeler.Views.Components.Diagram;

namespace Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;

public class PlantUmlHRSystemContextView : PlantUmlComponentsDiagramView
{
    public PlantUmlHRSystemContextView(SystemComponentsModel model)
    {
        VisibleComponents =
        [
            new VisibleComponent(model.GetComponent<HRSystemBoundary>()),
            new VisibleComponent(model.GetComponent<CRM>())
        ];
    }
}