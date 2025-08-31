using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Apis.Views.AsciiDoc;

public class AsciiDocHRApiEndpointsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocHRApiEndpointsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<EndpointsAsciiDocViewDefinition>(), "RestApiEndpoints.adoc");
    }
}