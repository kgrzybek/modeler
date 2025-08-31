using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Apis.Views.OpenApi.Yaml;

public class YamlApiFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public YamlApiFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<HROpenApiViewDefinition>(), "OpenApi.yaml");
    }
}