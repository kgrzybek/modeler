using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.ApiModelsList.AsciiDoc;

public class AsciiDocHRApiApiModelsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocHRApiApiModelsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<ApiModelsAsciiDocViewDefinition>(), "RestApiModels.adoc");
    }
}