using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.EventsFlow.Views.TableList.Markdown;

public class FileSystemMarkdownEventsFlowViewOutput : FileSystemMultipleViewsOutput
{
    public FileSystemMarkdownEventsFlowViewOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<MarkdownHREventsFlowView>(), "HREventsFlow.md");
    }
}
