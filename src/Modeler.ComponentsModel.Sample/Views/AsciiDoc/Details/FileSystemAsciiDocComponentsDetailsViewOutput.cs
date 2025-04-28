using Modeler.ComponentsModel.Views.Shared;

namespace Modeler.ComponentsModel.Sample.Views.AsciiDoc.Details;

public class FileSystemAsciiDocComponentsDetailsViewOutput<T>: IViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;

    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemAsciiDocComponentsDetailsViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;

        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(AsciiDocBackendDetailsViewDefinition.Id, "BackendDetails.adoc");
        _relativePaths.Add(AsciiDocFrontendDetailsViewDefinition.Id, "FrontendDetails.adoc");
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