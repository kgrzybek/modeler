using Modeler.Views.Common;

namespace Modeler.Full.Sample.EventsFlow.Views.Mermaid;

public class FileSystemMermaidEventsFlowDiagramViewOutput : FileSystemMultipleViewsOutput
{
    public FileSystemMermaidEventsFlowDiagramViewOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<HREventsFlowDiagramView>(), "HREventsFlow.mmd");
    }
}
