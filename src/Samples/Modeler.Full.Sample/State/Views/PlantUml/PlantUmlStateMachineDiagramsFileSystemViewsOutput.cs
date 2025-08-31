using Modeler.Views.Common;

namespace Modeler.Full.Sample.State.Views.PlantUml;

public class PlantUmlStateMachineDiagramsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public PlantUmlStateMachineDiagramsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<PlantUmlAbsenceStateMachineDiagramView>(), "AbsenceStateMachine.puml");
    }
}