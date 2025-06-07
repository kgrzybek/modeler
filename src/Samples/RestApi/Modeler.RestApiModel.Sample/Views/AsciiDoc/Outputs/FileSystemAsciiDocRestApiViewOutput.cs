using Modeler.RestApiModel.Views.AsciiDoc;

namespace Modeler.RestApiModel.Sample.Views.AsciiDoc.Outputs;

public class FileSystemAsciiDocRestApiViewOutput<T> : IAsciiDocRestApiViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;
    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemAsciiDocRestApiViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;
        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(EndpointsAsciiDocViewDefinition.Id, "RestApiEndpoints.adoc");
        _relativePaths.Add(ApiModelsAsciiDocViewDefinition.Id, "RestApiModels.adoc");
    }

    public void Execute(List<AsciiDocRestApiViewsOutputItem<T>> views)
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
