using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;
using Modeler.Views.Deployment.Diagram;

namespace Modeler.Samples.HR.Deployment.Views.PlantUml;

public class PlantUmlDeploymentDiagramViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public PlantUmlDeploymentDiagramViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<PlantUmlHRDeploymentView>(), "ProductionDeployment.puml");
    }
}
