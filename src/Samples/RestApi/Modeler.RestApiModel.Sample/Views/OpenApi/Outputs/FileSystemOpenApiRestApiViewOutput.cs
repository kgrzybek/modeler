using Modeler.RestApiModel.Views.OpenApi;

namespace Modeler.RestApiModel.Sample.Views.OpenApi.Outputs;

public class FileSystemOpenApiRestApiViewOutput<T> : IOpenApiRestApiViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;
    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemOpenApiRestApiViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;
        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(OpenApiJsonViewDefinition.Id, "OpenApi.json");
    }

    public void Execute(List<OpenApiRestApiViewsOutputItem<T>> views)
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
