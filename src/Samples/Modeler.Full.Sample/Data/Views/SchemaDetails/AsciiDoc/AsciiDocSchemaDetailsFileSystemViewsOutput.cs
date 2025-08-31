using Modeler.Views.Common;

namespace Modeler.Full.Sample.Data.Views.SchemaDetails;

public class AsciiDocSchemaDetailsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocSchemaDetailsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationsSchemaDetailsView>(), "SCHEMAS/organizations_schema.adoc");
    }
}