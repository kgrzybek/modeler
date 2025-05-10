using Modeler.EventsFlowModel.Views.Mermaid;

namespace Modeler.EventsFlowModel.Sample.Views.Mermaid;

public class FileSystemMermaidEventsFlowViewOutput<T> : IMermaidEventsFlowViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;

    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemMermaidEventsFlowViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;

        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(HREventsFlowViewDefinition.Id, "HREventsFlow.mmd");
    }

    public void Execute(List<MermaidEventsFlowViewsOutputItem<T>> views)
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