using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Apis.Views.AsciiDoc;

public class AsciiDocHRApiApiModelsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocHRApiApiModelsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<ApiModelsAsciiDocViewDefinition>(), "RestApiModels.adoc");
    }
}