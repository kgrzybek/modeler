using FluentAssertions;
using Modeler.DataModel.Tests.Sample;

namespace Modeler.DataModel.UnitTests;

public class OrganizationStructureModelTests
{
    [Test]
    public void Test()
    {
        var model = OrganizationStructureDataModel.GetInstance();

        var employeesTable = model.GetTable<EmployeesTable>();

        employeesTable.Should().NotBeNull();
        employeesTable.Schema.Name.Should().Be("organizations");
        employeesTable.Name.Should().Be("employees");
        employeesTable.Columns.Should().HaveCount(4);
        
        var idColumn = employeesTable.GetColumn("id");
        idColumn.Should().NotBeNull();
        idColumn.Name.Should().Be("id");
        idColumn.IsPrimaryKey.Should().BeTrue();
        idColumn.IsNullable.Should().BeFalse();

        var firstNameColumn = employeesTable.GetColumn("first_name");
        firstNameColumn.Should().NotBeNull();
        firstNameColumn.Name.Should().Be("first_name");
        firstNameColumn.IsNullable.Should().BeFalse();
        firstNameColumn.IsPrimaryKey.Should().BeFalse();
        
        var relationships = model.GetRelationships();
        relationships.Should().HaveCount(1);
        var relationship = relationships[0];

        relationship.From.Name.Should().Be("employees");
        relationship.FromColumnName.Should().Be("organization_unit_id");
        relationship.To.Name.Should().Be("organization_units");
        relationship.ToColumnName.Should().Be("id");
    }
}