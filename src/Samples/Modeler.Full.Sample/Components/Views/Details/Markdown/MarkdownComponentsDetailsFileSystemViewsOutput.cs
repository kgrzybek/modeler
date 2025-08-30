using Modeler.Views.Common;

namespace Modeler.Full.Sample.Components.Views.Details.Markdown;

public class MarkdownComponentsDetailsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public MarkdownComponentsDetailsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<MarkdownBackendComponentDetailsView>(), "BackendDetails_full.md");
        RelativePaths.Add(viewsRegistry.GetElement<MarkdownFrontendComponentDetailsView>(), "FrontendDetails_full.md");
    }
}