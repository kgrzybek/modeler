using FluentAssertions;
using Modeler.ConceptualModel.Sample.TestModel;

namespace Modeler.ConceptualModel.UnitTests;

public class SampleModelTests
{
    [Test]
    public void Test()
    {
        var model = OrganizationStructureConceptualModel.GetInstance();

        var employee = model.GetEntity<Employee>();

        employee.Should().NotBeNull();

        var associations = model.GetAssociations();
        associations.Should().HaveCount(2);
        
        var generalizations = model.GetGeneralizations();
        generalizations.Should().HaveCount(1);
        generalizations[0].General.Should().BeOfType<Employee>();
        generalizations[0].Specific.Should().BeOfType<Manager>();
    }
}