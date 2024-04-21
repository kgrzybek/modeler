using Modeler.ConceptualModel.Views.PlantUml.PlantUml;
using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.ConceptualModel.Sample.TestViews.Outputs;

public class FileSystemMermaidViewOutput : IViewsOutput
{
    private readonly string _absoluteDirectoryPath;

    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemMermaidViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;

        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(OrganizationStructureView.Id, "OrganizationStructure.mmd");
    }

    public void Execute(List<ViewOutputItem> views)
    {
        if (!Directory.Exists(_absoluteDirectoryPath))
        {
            Directory.CreateDirectory(_absoluteDirectoryPath);
        }
        
        foreach (var outputItem in views)
        {
            var relativePath = _relativePaths[outputItem.View.Id];
            var path = Path.Combine(_absoluteDirectoryPath, relativePath);

            File.WriteAllText(path, outputItem.Content);
        }
    }
}