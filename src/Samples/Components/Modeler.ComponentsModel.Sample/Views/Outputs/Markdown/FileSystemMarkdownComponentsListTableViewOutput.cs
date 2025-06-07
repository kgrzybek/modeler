using Modeler.ComponentsModel.Views.Markdown;

namespace Modeler.ComponentsModel.Sample.Views.Outputs.Markdown;

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

        var path = Path.Combine(_absoluteDirectoryPath, "ComponentsList.md");
        File.WriteAllText(path, content);
    }
}
