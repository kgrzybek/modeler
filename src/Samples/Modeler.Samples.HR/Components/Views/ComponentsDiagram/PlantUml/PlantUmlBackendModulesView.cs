using Modeler.Samples.HR.Components.Brokers;
using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.System;
using Modeler.Samples.HR.Components.System.Backend.Modules;
using Modeler.Samples.HR.Components.System.Frontend;
using Modeler.Views.Components.Diagram;

namespace Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;

public class PlantUmlBackendModulesView : PlantUmlComponentsDiagramView
{
    public PlantUmlBackendModulesView(SystemComponentsModel model)
    {
        VisibleComponents =
        [
            new VisibleComponent(model.GetComponent<HRSystemBoundary>(), nestedComponentsLevel: 3),
            new VisibleComponent(model.GetComponent<CRM>()),
            new VisibleComponent(model.GetComponent<MessagesBroker>()),
        ];

        HiddenRelationships =
        [
            new HiddenRelationship(model.GetComponent<HRBackendInfrastructureModule>(), model.GetComponent<CRM>())
        ];

        HiddenComponents =
            [
                model.GetComponent<HRFrontendApplication>()
            ];
    }
}