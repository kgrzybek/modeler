using Modeler.Views.Common;

namespace Modeler.Full.Sample.Apis.Views.AsciiDoc;

public class AsciiDocHRApiEndpointsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocHRApiEndpointsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<EndpointsAsciiDocViewDefinition>(), "RestApiEndpoints.adoc");
    }
}