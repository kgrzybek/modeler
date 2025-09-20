using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.OpenApi.Yaml;

public class YamlApiFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public YamlApiFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<HROpenApiViewDefinition>(), "OpenApi.yaml");
    }
}