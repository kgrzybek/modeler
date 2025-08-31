using Modeler.Views.Common;

namespace Modeler.Full.Sample.EventsFlow.Views.Markdown;

public class FileSystemMarkdownEventsFlowViewOutput : FileSystemMultipleViewsOutput
{
    public FileSystemMarkdownEventsFlowViewOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<MarkdownHREventsFlowView>(), "HREventsFlow.md");
    }
}
