using Modeler.StateModel.Tests.Sample.Views.PlantUml;
using Modeler.StateModel.Views.AsciiDoc;

namespace Modeler.StateModel.Tests.Sample.Views.AsciiDoc;

public class FileSystemAsciiDocStateMachineTableViewOutput<T> : IStateMachineAsciiDocTableViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;

    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemAsciiDocStateMachineTableViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;

        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(AbsenceStateMachinePlantUmlViewDefinition.Id, "AbsenceStateMachine.adoc");
    }

    public void Execute(List<StateMachineAsciiDocTableViewsOutputItem<T>> views)
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