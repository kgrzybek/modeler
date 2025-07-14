using Modeler.ComponentsModel.Views.Markdown;

namespace Modeler.Full.Sample.Components.Views.Outputs.Markdown;

public class FileSystemMarkdownComponentsListTableViewOutput : IMarkdownComponentsListTableViewOutput
{
    private readonly string _absoluteDirectoryPath;

    public FileSystemMarkdownComponentsListTableViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;
    }

    public void Execute(string content)
    {
        if (!Directory.Exists(_absoluteDirectoryPath))
        {
            Directory.CreateDirectory(_absoluteDirectoryPath);
        }

        var path = Path.Combine(_absoluteDirectoryPath, "ComponentsList_full.md");
        File.WriteAllText(path, content);
    }
}
