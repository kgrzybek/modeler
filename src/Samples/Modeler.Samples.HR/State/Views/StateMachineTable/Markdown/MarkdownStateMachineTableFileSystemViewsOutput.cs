using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.State.Views.StateMachineTable.Markdown;

public class MarkdownStateMachineTableFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public MarkdownStateMachineTableFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<AbsenceStateMachineMarkdownTableViewDefinition>(), "AbsenceStateMachine.md");
    }
}