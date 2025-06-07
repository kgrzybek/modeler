using Modeler.ComponentsModel.Sample.Views.Markdown.Details;
using Modeler.ComponentsModel.Views.Markdown.Details;
using Modeler.ComponentsModel.Views.Shared;

namespace Modeler.ComponentsModel.Sample.Views.Outputs.Markdown;

public class FileSystemMarkdownComponentsDetailsViewOutput<T> : IViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;
    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemMarkdownComponentsDetailsViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;
        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(MarkdownBackendDetailsViewDefinition.Id, "BackendDetails.md");
        _relativePaths.Add(MarkdownFrontendDetailsViewDefinition.Id, "FrontendDetails.md");
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
