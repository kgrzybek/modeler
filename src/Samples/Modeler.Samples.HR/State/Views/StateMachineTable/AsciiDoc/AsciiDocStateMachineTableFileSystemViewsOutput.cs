using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.State.Views.StateMachineTable.AsciiDoc;

public class AsciiDocStateMachineTableFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocStateMachineTableFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<AbsenceStateMachineAsciiDocTableViewDefinition>(), "AbsenceStateMachine.adoc");
    }
}