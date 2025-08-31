using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.EventsFlow.Views.TableList.AsciiDoc;

public class FileSystemAsciiDocEventsFlowViewOutput : FileSystemMultipleViewsOutput
{
    public FileSystemAsciiDocEventsFlowViewOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<AsciiDocHREventsFlowView>(), "HREventsFlow.adoc");
    }
}
