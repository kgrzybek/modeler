using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Components.System.Database.Views.DataModelDiagrams.Mermaid;

public class MermaidDataDiagramViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public MermaidDataDiagramViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationsMermaidView>(), "Organizations_data_model.mmd");
    }
}