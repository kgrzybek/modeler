using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Components.System.Database.Views.Sql;

public class SqlFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public SqlFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<SqlEmployeesTableView>(), "Scripts/Employees.sql");
        RelativePaths.Add(viewsRegistry.GetElement<SqlOrganizationUnitTableView>(), "Scripts/OrganizationUnit.sql");
    }
}