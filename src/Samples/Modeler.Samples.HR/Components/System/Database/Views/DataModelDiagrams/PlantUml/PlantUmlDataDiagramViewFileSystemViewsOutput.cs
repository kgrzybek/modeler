using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Components.System.Database.Views.DataModelDiagrams.PlantUml;

public class PlantUmlDataDiagramViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public PlantUmlDataDiagramViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationsPlantUmlView>(), "Organizations_data_model.puml");
    }
}