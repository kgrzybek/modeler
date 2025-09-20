using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;
using Modeler.Views.Components.Diagram;

namespace Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;

public class PlantUmlComponentsDiagramViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public PlantUmlComponentsDiagramViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<PlantUmlHRSystemContextView>(), "SystemContext.puml");
        RelativePaths.Add(viewsRegistry.GetElement<PlantUmlHRSystemComponentsView>(), "SystemComponents.puml");
        RelativePaths.Add(viewsRegistry.GetElement<PlantUmlHRSystemModulesView>(), "SystemModules.puml");
        RelativePaths.Add(viewsRegistry.GetElement<PlantUmlBackendModulesView>(), "BackendModules.puml");
    }
}