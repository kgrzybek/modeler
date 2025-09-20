using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.EndpointsList.AsciiDoc;

public class AsciiDocHRApiEndpointsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocHRApiEndpointsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<EndpointsAsciiDocViewDefinition>(), "RestApiEndpoints.adoc");
    }
}