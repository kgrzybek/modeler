using System.Reflection;
using FluentAssertions;
using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Sample.TestViews;
using Modeler.ConceptualModel.Sample.TestViews.Outputs;
using Modeler.ConceptualModel.Sample.TestViews.Translations;
using Modeler.ConceptualModel.Views.PlantUml.PlantUml;

namespace Modeler.ConceptualModel.UnitTests.Views;

[TestFixture]
public class ViewsTests
{
    [Test]
    public void FileSystemOutput_Test()
    {
        // Given
        var model = OrganizationStructureConceptualModel.GetInstance();
        var viewsFactory = new PlantUmlModelViewsFactory(
            model,
            Assembly.GetAssembly(typeof(OrganizationStructureView))!);

        var viewTranslator = new ViewTranslator();

        var generator = new PlantUmlGenerator(
            model, 
            4, 
            viewTranslator,
            new FileSystemViewOutput(AppDomain.CurrentDomain.BaseDirectory));
        
        // When
        generator.Generate(viewsFactory.GetViews());
        
        // Then
        var fileContent = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OrganizationStructure.puml"));
        var snapshot = File.ReadAllText("Views/OrganizationStructure_snapshot.puml");
        fileContent.Should().Be(snapshot);
    }
    
    [Test]
    public void MemoryOutput_Test()
    {
        // Given
        var model = OrganizationStructureConceptualModel.GetInstance();
        var viewsFactory = new PlantUmlModelViewsFactory(
            model,
            Assembly.GetAssembly(typeof(OrganizationStructureView))!);

        var viewTranslator = new ViewTranslator();

        var memoryViewOutput = new MemoryViewOutput();
        var generator = new PlantUmlGenerator(
            model, 
            4, 
            viewTranslator,
            memoryViewOutput);
        
        // When
        generator.Generate(viewsFactory.GetViews());
        
        // Then
        var views = memoryViewOutput.GetViews();
        views.Should().HaveCount(1);
        var snapshot = File.ReadAllText("Views/OrganizationStructure_snapshot.puml");
        views[0].Content.Should().Be(snapshot);
    }
}