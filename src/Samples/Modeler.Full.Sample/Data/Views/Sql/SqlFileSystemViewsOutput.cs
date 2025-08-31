using Modeler.Views.Common;

namespace Modeler.Full.Sample.Data.Views.Sql;

public class SqlFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public SqlFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<SqlEmployeesTableView>(), "Scripts/Employees.sql");
        RelativePaths.Add(viewsRegistry.GetElement<SqlOrganizationUnitTableView>(), "Scripts/OrganizationUnit.sql");
    }
}