using Modeler.Views.Common;

namespace Modeler.Full.Sample.Components.Views.ComponentsDiagram.PlantUml;

public class PlantUmlComponentsDiagramViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public PlantUmlComponentsDiagramViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<PlantUmlHRSystemComponentsView>(), "SystemComponents_full.puml");
    }
}