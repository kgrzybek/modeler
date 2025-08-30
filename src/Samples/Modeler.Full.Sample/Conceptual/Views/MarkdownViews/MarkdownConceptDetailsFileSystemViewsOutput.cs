using Modeler.Views.Common;

namespace Modeler.Full.Sample.Conceptual.Views.MarkdownViews;

public class MarkdownConceptDetailsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public MarkdownConceptDetailsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<AddressMarkdownView>(), "Address.md");
        RelativePaths.Add(viewsRegistry.GetElement<EmployeeMarkdownView>(), "Employee.md");
        RelativePaths.Add(viewsRegistry.GetElement<GenderMarkdownView>(), "Gender.md");
        RelativePaths.Add(viewsRegistry.GetElement<ManagerMarkdownView>(), "Manager.md");
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationUnitMarkdownView>(), "OrganizationUnit.md");
    }
}