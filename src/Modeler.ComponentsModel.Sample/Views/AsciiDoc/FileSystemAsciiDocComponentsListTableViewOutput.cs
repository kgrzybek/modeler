using Modeler.ComponentsModel.Views.AsciiDoc;

namespace Modeler.ComponentsModel.Sample.Views.AsciiDoc;

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
        
        var path = Path.Combine(_absoluteDirectoryPath, "ComponentsList.adoc");

        File.WriteAllText(path, content);
    }
}