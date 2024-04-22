using System.Reflection;
using FluentAssertions;
using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Sample.TestViews;
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
        var fileContent = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OrganizationStructure.mmd"));
        var snapshot = File.ReadAllText("Views/Mermaid/OrganizationStructure_snapshot.mmd");
        fileContent.Should().Be(snapshot);
    }
}