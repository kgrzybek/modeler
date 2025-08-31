using Modeler.Views.Common;

namespace Modeler.Full.Sample.Data.Views.SchemaDetails;

public class MarkdownSchemaDetailsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public MarkdownSchemaDetailsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationsSchemaDetailsView>(), "SCHEMAS/organizations_schema.md");
    }
}