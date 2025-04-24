// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Modeler.ComponentsModel.Tests.Sample;
using Modeler.ComponentsModel.Views.PlantUml;
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
using Modeler.SequenceModel.Tests.Sample;
using Modeler.SequenceModel.Tests.Sample.Views;
using Modeler.SequenceModel.Views.Mermaid;
using Modeler.SequenceModel.Views.PlantUml;
using Modeler.SequenceModel.Views.Shared;

Console.WriteLine("Docs generation...");

const string documentationPath = "C:\\Modeler_sample_docs";

GenerateConceptualModels(documentationPath);

GenerateDataModels(documentationPath);

GenerateSequenceModels(documentationPath);

GenerateComponentsModels(documentationPath);

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
        new Modeler.ConceptualModel.Sample.TestViews.Outputs.FileSystemPlantUmlViewOutput<ClassDiagramView>(modelsPath)).Generate(classDiagramViews);

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
    // Get model
    var model = OrganizationStructureDataModel.GetInstance();
    
    // Generate database scripts
    var dataModelPath = Path.Combine(path, "Models/Data");
    var fileSystemOutput = new FileSystemOutput(dataModelPath);
    new PostgreSqlStructureViewsGenerator(model, fileSystemOutput).Generate();

    // Generate data model diagrams
    var plantUmlDataModelViewsFactory = new PlantUmlDataModelViewsFactory(model);
    plantUmlDataModelViewsFactory.Initialize(Assembly.GetAssembly(typeof(EmployeesTable))!);
    var viewTranslator = new Modeler.DataModel.Tests.Sample.Views.Translations.ViewTranslator();
    
    PlantUmlDataModelGenerator.Generate(
        path,
        model, 
        4,
        plantUmlDataModelViewsFactory.Views,
        viewTranslator);
    
    // Generate ascii doc tables
    DataModelAsciiDocGenerator.Generate(dataModelPath, "organizations", model, viewTranslator);
}

void GenerateSequenceModels(string path)
{
    // Get model
    var model = SequencesModel.GetInstance();
    
    // Get views
    var sequenceDiagramViews = new SequenceDiagramViewsFactory(
        model,
        Assembly.GetAssembly(typeof(BasicSequenceView))!).GetViews();
    
    // Set views path
    var sequencesModelPath = Path.Combine(path, "Models/Sequences");
    
    // Generate views
    var fileSystemOutput = new FileSystemSequencesPlantUmlSequenceDiagramViewOutput<SequenceDiagramView>(sequencesModelPath);
    var viewTranslator = new SequenceDiagramViewTranslator();
    var viewLayout = new DefaultViewLayout();
    
    // Generate PlantUml views
    new PlantUmlSequenceDiagramViewGenerator(fileSystemOutput, viewTranslator, viewLayout).Generate(sequenceDiagramViews);
    
    // Generate Mermaid views
    var mermaidFilesOutput = new FileSystemSequencesMermaidSequenceDiagramViewOutput<SequenceDiagramView>(sequencesModelPath);
    new MermaidSequenceDiagramViewGenerator(mermaidFilesOutput, viewTranslator).Generate(sequenceDiagramViews);
}

void GenerateComponentsModels(string path)
{
    var model = SystemComponentsModel.GetInstance();
    
    // Get views
    var sequenceDiagramViews = new ComponentsDiagramViewsFactory(
        model,
        Assembly.GetAssembly(typeof(SystemComponentsView))!).GetViews();
    
    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/Components");
    
    // Generate views
    var fileSystemOutput = new FileSystemPlantUmlComponentsDiagramViewOutput<ComponentsDiagramView>(componentsModelPath);
    new PlantComponentsDiagramViewGenerator(model, fileSystemOutput).Generate(sequenceDiagramViews);

}