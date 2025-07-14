using Modeler.ComponentsModel.Views.AsciiDoc;

namespace Modeler.Full.Sample.Components.Views.AsciiDoc;

public class FileSystemAsciiDocComponentsListTableViewOutput : IAsciiDocComponentsListTableViewOutput
{
    private readonly string _absoluteDirectoryPath;

    public FileSystemAsciiDocComponentsListTableViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;
    }

    public void Execute(string content)
    {
        if (!Directory.Exists(_absoluteDirectoryPath))
        {
            Directory.CreateDirectory(_absoluteDirectoryPath);
        }
        
        var path = Path.Combine(_absoluteDirectoryPath, "ComponentsList_full.adoc");

        File.WriteAllText(path, content);
    }
}