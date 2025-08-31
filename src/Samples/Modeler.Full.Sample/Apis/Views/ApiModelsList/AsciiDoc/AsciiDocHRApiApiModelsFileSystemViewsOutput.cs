using Modeler.Views.Common;

namespace Modeler.Full.Sample.Apis.Views.AsciiDoc;

public class AsciiDocHRApiApiModelsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocHRApiApiModelsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<ApiModelsAsciiDocViewDefinition>(), "RestApiModels.adoc");
    }
}