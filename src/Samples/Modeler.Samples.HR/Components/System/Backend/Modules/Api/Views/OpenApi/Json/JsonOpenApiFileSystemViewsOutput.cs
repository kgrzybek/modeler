using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.OpenApi.Json;

public class JsonOpenApiFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public JsonOpenApiFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<HROpenApiViewDefinition>(), "OpenApi.json");
    }
}