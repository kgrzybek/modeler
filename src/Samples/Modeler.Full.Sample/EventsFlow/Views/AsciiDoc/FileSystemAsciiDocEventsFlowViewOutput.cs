using Modeler.Views.Common;

namespace Modeler.Full.Sample.EventsFlow.Views.AsciiDoc;

public class FileSystemAsciiDocEventsFlowViewOutput : FileSystemMultipleViewsOutput
{
    public FileSystemAsciiDocEventsFlowViewOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<AsciiDocHREventsFlowView>(), "HREventsFlow.adoc");
    }
}
