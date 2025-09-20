using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Components.System.Database.Views.SchemaDetails.Markdown;

public class MarkdownSchemaDetailsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public MarkdownSchemaDetailsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationsSchemaDetailsView>(), "SCHEMAS/organizations_schema.md");
    }
}