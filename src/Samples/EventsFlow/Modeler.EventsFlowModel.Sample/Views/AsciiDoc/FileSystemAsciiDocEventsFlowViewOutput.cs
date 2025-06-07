using Modeler.EventsFlowModel.Views.AsciiDoc;

namespace Modeler.EventsFlowModel.Sample.Views.AsciiDoc;

public class FileSystemAsciiDocEventsFlowViewOutput<T> : IAsciiDocEventsFlowViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;
    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemAsciiDocEventsFlowViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;
        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(HREventsFlowAsciiDocViewDefinition.Id, "HREventsFlow.adoc");
    }

    public void Execute(List<AsciiDocEventsFlowViewsOutputItem<T>> views)
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
