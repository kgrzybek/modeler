using Modeler.Views.Common;

namespace Modeler.Full.Sample.State.Views.StateMachineTable.AsciiDoc;

public class AsciiDocStateMachineTableFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocStateMachineTableFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<AbsenceStateMachineAsciiDocTableViewDefinition>(), "AbsenceStateMachine.adoc");
    }
}