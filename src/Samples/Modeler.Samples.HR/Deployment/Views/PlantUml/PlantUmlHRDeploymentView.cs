using Modeler.Samples.HR.Deployment.Environments;
using Modeler.Views.Deployment.Diagram;

namespace Modeler.Samples.HR.Deployment.Views.PlantUml;

public class PlantUmlHRDeploymentView : PlantUmlDeploymentDiagramView
{
    public PlantUmlHRDeploymentView(HRDeploymentModel model)
    {
        VisibleEnvironments =
        [
            new VisibleDeploymentEnvironment(model.GetEnvironment<ProductionEnvironment>())
        ];
    }
}
