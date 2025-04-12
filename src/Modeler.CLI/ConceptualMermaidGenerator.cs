using System.Reflection;
using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Sample.TestViews;
using Modeler.ConceptualModel.Sample.TestViews.Outputs;
using Modeler.ConceptualModel.Sample.TestViews.Translations;
using Modeler.ConceptualModel.Views.Mermaid;
using Modeler.ConceptualModel.Views.PlantUml;
using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.CLI;

internal static class ConceptualMermaidGenerator
{
    internal static void Generate(
        OrganizationStructureConceptualModel model,
        IViewTranslator viewTranslator,
        ClassDiagramViewsFactory viewsFactory,
        string modelsPath)
    {
        var generator = new MermaidClassDiagramViewGenerator(
            model, 
            4, 
            viewTranslator,
            new FileSystemMermaidViewOutput<ClassDiagramView>(modelsPath));

        generator.Generate(viewsFactory.GetViews());
    }
}