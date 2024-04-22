using System.Reflection;
using FluentAssertions;
using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Sample.TestViews;
using Modeler.ConceptualModel.Sample.TestViews.Outputs;
using Modeler.ConceptualModel.Sample.TestViews.Translations;
using Modeler.ConceptualModel.Views.Mermaid;
using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.ConceptualModel.UnitTests.Views.Mermaid;

[TestFixture]
public class MermaidUmlViewsTests
{
    [Test]
    public void FileSystemOutput_Test()
    {
        // Given
        var model = OrganizationStructureConceptualModel.GetInstance();
        var viewsFactory = new ClassDiagramViewsFactory(
            model,
            Assembly.GetAssembly(typeof(OrganizationStructureView))!);

        var viewTranslator = new ViewTranslator();

        var generator = new MermaidClassDiagramViewGenerator(
            model, 
            4, 
            viewTranslator,
            new FileSystemMermaidViewOutput<ClassDiagramView>(AppDomain.CurrentDomain.BaseDirectory));
        
        // When
        generator.Generate(viewsFactory.GetViews());
        
        // Then
        var fileContent = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OrganizationStructure.mmd"));
        var snapshot = File.ReadAllText("Views/Mermaid/OrganizationStructure_snapshot.mmd");
        fileContent.Should().Be(snapshot);
    }
    
    [Test]
    public void MemoryOutput_Test()
    {
        // Given
        var model = OrganizationStructureConceptualModel.GetInstance();
        var viewsFactory = new ClassDiagramViewsFactory(
            model,
            Assembly.GetAssembly(typeof(OrganizationStructureView))!);
    
        var viewTranslator = new ViewTranslator();
    
        var memoryViewOutput = new MemoryViewOutput<ClassDiagramView>();
        var generator = new MermaidClassDiagramViewGenerator(
            model, 
            4, 
            viewTranslator,
            memoryViewOutput);
        
        // When
        generator.Generate(viewsFactory.GetViews());
        
        // Then
        var views = memoryViewOutput.GetViews();
        views.Should().HaveCount(1);
        var snapshot = File.ReadAllText("Views/Mermaid/OrganizationStructure_snapshot.mmd");
        views[0].Content.Should().Be(snapshot);
    }
}