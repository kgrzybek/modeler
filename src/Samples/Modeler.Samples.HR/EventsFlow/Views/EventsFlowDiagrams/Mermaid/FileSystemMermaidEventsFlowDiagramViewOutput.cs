using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.EventsFlow.Views.EventsFlowDiagrams.Mermaid;

public class FileSystemMermaidEventsFlowDiagramViewOutput : FileSystemMultipleViewsOutput
{
    public FileSystemMermaidEventsFlowDiagramViewOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<HREventsFlowDiagramView>(), "HREventsFlow.mmd");
    }
}
