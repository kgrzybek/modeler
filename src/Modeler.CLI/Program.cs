// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Sample.TestViews;
using Modeler.ConceptualModel.Sample.TestViews.AsciiDocViews;
using Modeler.ConceptualModel.Sample.TestViews.Outputs;
using Modeler.ConceptualModel.Sample.TestViews.Translations;
using Modeler.ConceptualModel.Views.AsciiDoc;
using Modeler.ConceptualModel.Views.Mermaid;
using Modeler.ConceptualModel.Views.PlantUml;
using Modeler.ConceptualModel.Views.Shared;
using Modeler.DataModel.PostgreSQL.Views.Generator;
using Modeler.DataModel.Tests.Sample;

Console.WriteLine("Docs generation...");

const string documentationPath = "C:\\Modeler_sample_docs";

GenerateConceptualModels(documentationPath);

GenerateDataModels(documentationPath);

Console.WriteLine("Docs generated...");


void GenerateConceptualModels(string path)
{
    // Get model
    var model = OrganizationStructureConceptualModel.GetInstance();

    // Views to generate
    var classDiagramViews = new ClassDiagramViewsFactory(
        model,
        Assembly.GetAssembly(typeof(OrganizationStructureView))!).GetViews();

    // Views translations
    var viewTranslator = new ViewTranslator();

    // Path for models
    var modelsPath = Path.Combine(path, "Models/Conceptual");

    // PlantUML
    new PlantUmlClassDiagramViewGenerator(
        model,
        4,
        viewTranslator,
        new FileSystemPlantUmlViewOutput<ClassDiagramView>(modelsPath)).Generate(classDiagramViews);

    // Mermaid
    new MermaidClassDiagramViewGenerator(
        model,
        4,
        viewTranslator,
        new FileSystemMermaidViewOutput<ClassDiagramView>(modelsPath)).Generate(classDiagramViews);

    // AsciiDoc
    var asciiDocsViewsFactory = new AsciiDocViewsFactory(
        model,
        Assembly.GetAssembly(typeof(EmployeeAsciiDocView))!);
    new AsciiDocViewsGenerator(
        model,
        viewTranslator,
        new FileSystemAsciiDocViewOutput<AsciiDocView>(modelsPath),
        new AsciiDocViewTranslationDictionary()).Generate(asciiDocsViewsFactory.GetViews());
}

void GenerateDataModels(string path)
{
    var model = OrganizationStructureDataModel.GetInstance();

    var dataModelPath = Path.Combine(path, "Models/Data");
    var fileSystemOutput = new FileSystemOutput(dataModelPath);
        
    new PostgreSqlStructureViewsGenerator(model, fileSystemOutput).Generate();
}