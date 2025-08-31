using Modeler.Views.Common;

namespace Modeler.Full.Sample.Apis.Views.OpenApi.Json;

public class JsonOpenApiFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public JsonOpenApiFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<HROpenApiViewDefinition>(), "OpenApi.json");
    }
}