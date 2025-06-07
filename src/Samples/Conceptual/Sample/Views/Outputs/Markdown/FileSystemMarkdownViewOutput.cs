using Modeler.ConceptualModel.Sample.Views.MarkdownViews;
using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.ConceptualModel.Sample.Views.Outputs;

public class FileSystemMarkdownViewOutput<T>: IViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;

    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemMarkdownViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;

        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(EmployeeMarkdownView.Id, "Employee.md");
        _relativePaths.Add(ManagerMarkdownView.Id, "Manager.md");
        _relativePaths.Add(GenderMarkdownView.Id, "Gender.md");
        _relativePaths.Add(AddressMarkdownView.Id, "Address.md");
        _relativePaths.Add(OrganizationUnitMarkdownView.Id, "OrganizationUnit.md");
    }

    public void Execute(List<ViewOutputItem<T>> views)
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
