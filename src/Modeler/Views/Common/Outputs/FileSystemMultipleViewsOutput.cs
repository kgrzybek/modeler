namespace Modeler.Views.Common.Outputs;

public abstract class FileSystemMultipleViewsOutput : IMultipleViewsOutput
{
    private readonly string _absoluteDirectoryPath;
    
    protected IDictionary<IView, string> RelativePaths { get; init; }

    protected FileSystemMultipleViewsOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;
        RelativePaths = new Dictionary<IView, string>();
    }

    public void Execute(List<ViewOutputItem> items)
    {
        if (!Directory.Exists(_absoluteDirectoryPath))
        {
            Directory.CreateDirectory(_absoluteDirectoryPath);
        }
        
        foreach (var outputItem in items)
        {
            var relativePath = RelativePaths[outputItem.View];
            var path = Path.Combine(_absoluteDirectoryPath, relativePath);

            File.WriteAllText(path, outputItem.Content);
        }
    }
}