using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDetails.Markdown;

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