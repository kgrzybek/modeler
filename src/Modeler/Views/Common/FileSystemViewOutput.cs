namespace Modeler.Views.Common;

public class FileSystemViewOutput : IViewOutput
{
    private readonly string _absoluteDirectoryPath;

    private readonly string _fileName;

    public FileSystemViewOutput(string absoluteDirectoryPath, string fileName)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;
        _fileName = fileName;
    }

    public void Execute(string content)
    {
        if (!Directory.Exists(_absoluteDirectoryPath))
        {
            Directory.CreateDirectory(_absoluteDirectoryPath);
        }
        
        var path = Path.Combine(_absoluteDirectoryPath, _fileName);

        File.WriteAllText(path, content);
    }
}