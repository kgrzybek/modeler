using Modeler.EventsFlowModel.Views.Markdown;

namespace Modeler.EventsFlowModel.Sample.Views.Markdown;

public class FileSystemMarkdownEventsFlowViewOutput<T> : IMarkdownEventsFlowViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;
    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemMarkdownEventsFlowViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;
        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(HREventsFlowMarkdownViewDefinition.Id, "HREventsFlow.md");
    }

    public void Execute(List<MarkdownEventsFlowViewsOutputItem<T>> views)
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
