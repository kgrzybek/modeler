using Modeler.SequenceModel.Views.Shared;

namespace Modeler.SequenceModel.Sample.Views.Outputs;

public class FileSystemSequencesPlantUmlSequenceDiagramViewOutput<T> : ISequenceDiagramViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;

    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemSequencesPlantUmlSequenceDiagramViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;

        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(BasicSequenceView.Id, "BasicSequence.puml");
        _relativePaths.Add(BasicSequencePartView.Id, "BasicSequencePart.puml");
    }

    public void Execute(List<SequenceDiagramViewOutputItem<T>> views)
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