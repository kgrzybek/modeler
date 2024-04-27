using System.Reflection;
using FluentAssertions;
using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Sample.TestViews;
using Modeler.ConceptualModel.Sample.TestViews.AsciiDocViews;
using Modeler.ConceptualModel.Sample.TestViews.Outputs;
using Modeler.ConceptualModel.Sample.TestViews.Translations;
using Modeler.ConceptualModel.Views.AsciiDoc;

namespace Modeler.ConceptualModel.UnitTests.Views.AsciiDoc;

[TestFixture]
public class AsciiDocViewsTests
{
    [Test]
    public void FileSystemOutput_Test()
    {
        // Given
        var model = OrganizationStructureConceptualModel.GetInstance();
        var viewsFactory = new AsciiDocViewsFactory(
            model,
            Assembly.GetAssembly(typeof(EmployeeAsciiDocView))!);

        var viewTranslator = new ViewTranslator();

        var generator = new AsciiDocViewsGenerator(
            model, 
            viewTranslator,
            new FileSystemAsciiDocViewOutput<AsciiDocView>(AppDomain.CurrentDomain.BaseDirectory),
            new AsciiDocViewTranslationDictionary());
        
        // When
        generator.Generate(viewsFactory.GetViews());
        
        // Then
        var fileContent = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Employee.adoc"));
        var snapshot = File.ReadAllText("Views/AsciiDoc/Employee_snapshot.adoc");
        fileContent.Should().Be(snapshot);
    }
    
    [Test]
    public void MemoryOutput_Test()
    {
        // Given
        var model = OrganizationStructureConceptualModel.GetInstance();
        var viewsFactory = new AsciiDocViewsFactory(
            model,
            Assembly.GetAssembly(typeof(OrganizationStructureView))!);
    
        var viewTranslator = new ViewTranslator();
    
        var memoryViewOutput = new MemoryViewOutput<AsciiDocView>();
        var generator = new AsciiDocViewsGenerator(
            model, 
            viewTranslator,
            memoryViewOutput);
        
        // When
        generator.Generate(viewsFactory.GetViews());
        
        // Then
        var views = memoryViewOutput.GetViews();
        views.Should().HaveCount(4);
        
        var employeeSnapshot = File.ReadAllText("Views/AsciiDoc/Employee_snapshot.adoc");
        views.Single(x => x.Id == EmployeeAsciiDocView.Id).Content.Should().Be(employeeSnapshot);
        
        var managerSnapshot = File.ReadAllText("Views/AsciiDoc/Manager_snapshot.adoc");
        views.Single(x => x.Id == ManagerAsciiDocView.Id).Content.Should().Be(managerSnapshot);
        
        var genderSnapshot = File.ReadAllText("Views/AsciiDoc/Gender_snapshot.adoc");
        views.Single(x => x.Id == GenderAsciiDocView.Id).Content.Should().Be(genderSnapshot);
        
        var addressSnapshot = File.ReadAllText("Views/AsciiDoc/Address_snapshot.adoc");
        views.Single(x => x.Id == AddressAsciiDocView.Id).Content.Should().Be(addressSnapshot);
    }
}