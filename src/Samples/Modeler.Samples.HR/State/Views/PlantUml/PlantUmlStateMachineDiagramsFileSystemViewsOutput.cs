using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.State.Views.PlantUml;

public class PlantUmlStateMachineDiagramsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public PlantUmlStateMachineDiagramsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<PlantUmlAbsenceStateMachineDiagramView>(), "AbsenceStateMachine.puml");
    }
}