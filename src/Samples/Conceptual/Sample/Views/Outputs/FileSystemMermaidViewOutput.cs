using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.ConceptualModel.Sample.Views.Outputs;

public class FileSystemMermaidViewOutput<T>: IViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;

    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemMermaidViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;

        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(OrganizationStructureView.Id, "OrganizationStructure.mmd");
    }

    public void Execute(List<ViewOutputItem<T>> views)
    {
        if (!Directory.Exists(_absoluteDirectoryPath))
        {
            Directory.CreateDirectory(_absoluteDirectoryPath);
        }
        
        foreach (var outputItem in views)
        {
            var relativePath = _relativePaths[outputItem.Id];
            var path = Path.Combine(_absoluteDirectoryPath, relativePath);

            File.WriteAllText(path, outputItem.Content);
        }
    }
}