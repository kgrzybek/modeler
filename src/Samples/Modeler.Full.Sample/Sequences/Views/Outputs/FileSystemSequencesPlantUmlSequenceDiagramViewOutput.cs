using Modeler.SequenceModel.Views.Shared;

namespace Modeler.Full.Sample.Sequences.Views.Outputs;

public class FileSystemSequencesPlantUmlSequenceDiagramViewOutput<T> : ISequenceDiagramViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;

    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemSequencesPlantUmlSequenceDiagramViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;

        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(BasicSequenceView.Id, "BasicSequence_full.puml");
        _relativePaths.Add(BasicSequencePartView.Id, "BasicSequencePart_full.puml");
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