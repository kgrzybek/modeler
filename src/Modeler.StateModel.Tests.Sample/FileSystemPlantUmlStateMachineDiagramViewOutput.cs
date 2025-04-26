using Modeler.StateModel.Views.PlantUml;

namespace Modeler.StateModel.Tests.Sample;

public class FileSystemPlantUmlStateMachineDiagramViewOutput<T> : IStateMachineViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;

    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemPlantUmlStateMachineDiagramViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;

        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(AbsenceStateMachineViewDefinition.Id, "AbsenceStateMachine.puml");
    }

    public void Execute(List<StateMachineViewOutputItem<T>> views)
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