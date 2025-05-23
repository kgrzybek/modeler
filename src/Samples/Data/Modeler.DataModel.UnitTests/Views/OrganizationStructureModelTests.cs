using FluentAssertions;
using Modeler.DataModel.PostgreSQL.Views.SQL.Generator;
using Modeler.DataModel.Sample;
using Modeler.DataModel.Sample.Structure;
using Modeler.DataModel.Sample.Views.Outputs;

namespace Modeler.DataModel.UnitTests.Views;

public class Tests
{
    [Test]
    public void Test()
    {
        // Given
        var model = HRDataModel.GetInstance();
        
        var memoryViewOutput = new MemoryViewOutput();
        
        // When
        var generator = new PostgreSqlStructureViewsGenerator(model, memoryViewOutput);
        generator.Generate();

        // Then
        memoryViewOutput.Views.Should().HaveCount(2);
        var employeesTableView = memoryViewOutput.Views.Single(x => x.StructureName == "organizations.employees");

        var snapshot = File.ReadAllText("Views/employees.sql");
        employeesTableView.Content.Should().Be(snapshot);
    }
}