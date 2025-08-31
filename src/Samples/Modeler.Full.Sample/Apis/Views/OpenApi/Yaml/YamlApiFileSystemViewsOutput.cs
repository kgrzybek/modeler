using Modeler.Views.Common;

namespace Modeler.Full.Sample.Apis.Views.OpenApi.Yaml;

public class YamlApiFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public YamlApiFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<HROpenApiViewDefinition>(), "OpenApi.yaml");
    }
}