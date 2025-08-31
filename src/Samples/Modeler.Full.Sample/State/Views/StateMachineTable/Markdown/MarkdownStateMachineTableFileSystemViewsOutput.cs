using Modeler.Views.Common;

namespace Modeler.Full.Sample.State.Views.StateMachineTable.Markdown;

public class MarkdownStateMachineTableFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public MarkdownStateMachineTableFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<AbsenceStateMachineMarkdownTableViewDefinition>(), "AbsenceStateMachine.md");
    }
}