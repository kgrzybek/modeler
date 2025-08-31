using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Data.Views.SchemaDetails;

public class AsciiDocSchemaDetailsFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public AsciiDocSchemaDetailsFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationsSchemaDetailsView>(), "SCHEMAS/organizations_schema.adoc");
    }
}