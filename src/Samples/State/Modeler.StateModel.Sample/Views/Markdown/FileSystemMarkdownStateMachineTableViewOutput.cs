using Modeler.StateModel.Sample.Views.PlantUml;
using Modeler.StateModel.Views.Markdown;

namespace Modeler.StateModel.Sample.Views.Markdown;

public class FileSystemMarkdownStateMachineTableViewOutput<T> : IStateMachineMarkdownTableViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;
    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemMarkdownStateMachineTableViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;
        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(AbsenceStateMachinePlantUmlViewDefinition.Id, "AbsenceStateMachine.md");
    }

    public void Execute(List<StateMachineMarkdownTableViewsOutputItem<T>> views)
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
