using Modeler.ConceptualModel.Sample.Views.AsciiDocViews;
using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.ConceptualModel.Sample.Views.Outputs;

public class FileSystemAsciiDocViewOutput<T>: IViewsOutput<T>
{
    private readonly string _absoluteDirectoryPath;

    private readonly IDictionary<string, string> _relativePaths;

    public FileSystemAsciiDocViewOutput(string absoluteDirectoryPath)
    {
        _absoluteDirectoryPath = absoluteDirectoryPath;

        _relativePaths = new Dictionary<string, string>();
        _relativePaths.Add(EmployeeAsciiDocView.Id, "Employee.adoc");
        _relativePaths.Add(ManagerAsciiDocView.Id, "Manager.adoc");
        _relativePaths.Add(GenderAsciiDocView.Id, "Gender.adoc");
        _relativePaths.Add(AddressAsciiDocView.Id, "Address.adoc");
        _relativePaths.Add(OrganizationUnitAsciiDocView.Id, "OrganizationUnit.adoc");
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