using Modeler.Views.Common;

namespace Modeler.Full.Sample.Components.Views.Details.AsciiDoc;

public class AsciiDocComponentsDetailsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocComponentsDetailsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<AsciiDocBackendComponentDetailsView>(), "BackendDetails_full.adoc");
        RelativePaths.Add(viewsRegistry.GetElement<AsciiDocFrontendComponentDetailsView>(), "FrontendDetails_full.adoc");
    }
}