using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Sample.TestViews.Outputs;
using Modeler.ConceptualModel.Views.PlantUml;
using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.CLI;

internal static class ConceptualPlantUmlGenerator
{
    internal static void Generate(
        OrganizationStructureConceptualModel model,
        IViewTranslator viewTranslator,
        ClassDiagramViewsFactory viewsFactory,
        string modelsPath)
    {
        var generator = new PlantUmlClassDiagramViewGenerator(
            model, 
            4, 
            viewTranslator,
            new FileSystemPlantUmlViewOutput<ClassDiagramView>(modelsPath));

        generator.Generate(viewsFactory.GetViews());
    }
}