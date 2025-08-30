using Modeler.Views.Common;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

public class AsciiDocConceptDetailsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocConceptDetailsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<AddressAsciiDocView>(), "Address.adoc");
        RelativePaths.Add(viewsRegistry.GetElement<EmployeeAsciiDocView>(), "Employee.adoc");
        RelativePaths.Add(viewsRegistry.GetElement<GenderAsciiDocView>(), "Gender.adoc");
        RelativePaths.Add(viewsRegistry.GetElement<ManagerAsciiDocView>(), "Manager.adoc");
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationUnitAsciiDocView>(), "OrganizationUnit.adoc");
    }
}