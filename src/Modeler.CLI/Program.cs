// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Modeler.ComponentsModel.Sample.Components;
using Modeler.ComponentsModel.Sample.Views;
using Modeler.ComponentsModel.Sample.Views.AsciiDoc;
using Modeler.ComponentsModel.Sample.Views.AsciiDoc.Details;
using Modeler.ComponentsModel.Sample.Views.Outputs;
using Modeler.ComponentsModel.Sample.Views.Markdown.Details;
using Modeler.ComponentsModel.Sample.Views.Outputs.Markdown;
using Modeler.ComponentsModel.Views.AsciiDoc;
using Modeler.ComponentsModel.Views.AsciiDoc.Details;
using Modeler.ComponentsModel.Views.Markdown;
using Modeler.ComponentsModel.Views.Markdown.Details;
using Modeler.ComponentsModel.Views.PlantUml;
using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Views;
using Modeler.ConceptualModel.Sample.Views.AsciiDocViews;
using Modeler.ConceptualModel.Sample.Views.MarkdownViews;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.ConceptualModel.Sample.Views.Outputs;
using Modeler.ConceptualModel.Sample.Views.Translations;
using Modeler.ConceptualModel.Views.AsciiDoc;
using Modeler.ConceptualModel.Views.PlantUml;
using Modeler.ConceptualModel.Views.Shared;
using Modeler.DataModel.PostgreSQL.Views.AsciiDoc;
using Modeler.DataModel.PostgreSQL.Views.PlantUml;
using Modeler.DataModel.PostgreSQL.Views.Markdown;
using Modeler.DataModel.PostgreSQL.Views.SQL.Generator;
using Modeler.DataModel.Sample.Structure;
using Modeler.DataModel.Sample.Structure.Tables;
using Modeler.DataModel.Sample.Views.Outputs;
using Modeler.EventsFlowModel.Sample;
using Modeler.EventsFlowModel.Sample.Views.Mermaid;
using Modeler.EventsFlowModel.Views.Mermaid;
using Modeler.SequenceModel.Sample.Models;
using Modeler.SequenceModel.Sample.Views;
using Modeler.SequenceModel.Sample.Views.Layouts;
using Modeler.SequenceModel.Sample.Views.Outputs;
using Modeler.SequenceModel.Sample.Views.Translations;
using Modeler.SequenceModel.Views.Mermaid;
using Modeler.SequenceModel.Views.PlantUml;
using Modeler.SequenceModel.Views.Shared;
using Modeler.StateModel.Sample.Models;
using Modeler.StateModel.Sample.Views.AsciiDoc;
using Modeler.StateModel.Sample.Views.PlantUml;
using Modeler.StateModel.Views.AsciiDoc;
using Modeler.StateModel.Views.PlantUml;
using MermaidClassDiagramViewGenerator = Modeler.ConceptualModel.Views.Mermaid.MermaidClassDiagramViewGenerator;

if (args.Length != 1)
{
    throw new Exception("Provide path to documentation output directory");
}

var documentationPath = args[0];

Console.WriteLine($"Documentation generation to {documentationPath} started.");

GenerateConceptualModels(documentationPath);

GenerateDataModels(documentationPath);

GenerateSequenceModels(documentationPath);

GenerateComponentsModels(documentationPath);

GeneratePlantUmlStateMachineViews(documentationPath);

GenerateAsciiDocStateMachineTableViews(documentationPath);

GenerateMermaidEventsFlowViews(documentationPath);

Console.WriteLine("Documentation generated.");


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

    // Markdown
    var markdownViewsFactory = new MarkdownViewsFactory(
        model,
        Assembly.GetAssembly(typeof(EmployeeMarkdownView))!);
    new MarkdownViewsGenerator(
        model,
        viewTranslator,
        new FileSystemMarkdownViewOutput<MarkdownView>(modelsPath),
        new MarkdownViewTranslationDictionary()).Generate(markdownViewsFactory.GetViews());
}

void GenerateDataModels(string path)
{
    // Get model
    var model = HRDataModel.GetInstance();
    
    // Generate database scripts
    var dataModelPath = Path.Combine(path, "Models/Data");
    var fileSystemOutput = new FileSystemOutput(dataModelPath);
    new PostgreSqlStructureViewsGenerator(model, fileSystemOutput).Generate();

    // Generate data model diagrams
    var plantUmlDataModelViewsFactory = new PlantUmlDataModelViewsFactory(model);
    plantUmlDataModelViewsFactory.Initialize(Assembly.GetAssembly(typeof(EmployeesTable))!);
    var viewTranslator = new Modeler.DataModel.Sample.Views.Translations.ViewTranslator();
    
    PlantUmlDataModelGenerator.Generate(
        path,
        model,
        4,
        plantUmlDataModelViewsFactory.Views,
        viewTranslator);

    // Generate ascii doc tables
    DataModelAsciiDocGenerator.Generate(dataModelPath, "organizations", model, viewTranslator);

    // Generate markdown tables
    DataModelMarkdownGenerator.Generate(dataModelPath, "organizations", model, viewTranslator);
}

void GenerateSequenceModels(string path)
{
    // Get model
    var model = HRSequencesModel.GetInstance();
    
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
    
    // Generate PlantUML views
    var fileSystemOutput = new FileSystemPlantUmlComponentsDiagramViewOutput<ComponentsDiagramView>(componentsModelPath);
    new PlantComponentsDiagramViewGenerator(model, fileSystemOutput, new ComponentsDiagramDefaultViewLayout()).Generate(sequenceDiagramViews);
    
    // Generate AsciiDoc components list view
    var fileSystemAsciiDocComponentsListTableViewOutput = new FileSystemAsciiDocComponentsListTableViewOutput(componentsModelPath);
    new AsciiDocComponentsListTableViewGenerator(model, fileSystemAsciiDocComponentsListTableViewOutput).Generate();
    
    // Generate AsciiDoc components details views
    var asciiDocDetailsViews = new AsciiDocComponentsDetailsViewsFactory(
        model,
        Assembly.GetAssembly(typeof(AsciiDocBackendDetailsViewDefinition))!).GetViews();
    var fileSystemAsciiDocComponentsDetailsViewOutput = new FileSystemAsciiDocComponentsDetailsViewOutput<AsciiDocComponentDetailsView>(componentsModelPath);
    new AsciiDocComponentsDetailsViewsGenerator(model, fileSystemAsciiDocComponentsDetailsViewOutput).Generate(asciiDocDetailsViews);

    // Generate Markdown components list view
    var fileSystemMarkdownComponentsListTableViewOutput = new FileSystemMarkdownComponentsListTableViewOutput(componentsModelPath);
    new MarkdownComponentsListTableViewGenerator(model, fileSystemMarkdownComponentsListTableViewOutput).Generate();

    // Generate Markdown components details views
    var markdownDetailsViews = new MarkdownComponentsDetailsViewsFactory(
        model,
        Assembly.GetAssembly(typeof(MarkdownBackendDetailsViewDefinition))!).GetViews();
    var fileSystemMarkdownComponentsDetailsViewOutput = new FileSystemMarkdownComponentsDetailsViewOutput<MarkdownComponentDetailsView>(componentsModelPath);
    new MarkdownComponentsDetailsViewsGenerator(model, fileSystemMarkdownComponentsDetailsViewOutput).Generate(markdownDetailsViews);
}

void GeneratePlantUmlStateMachineViews(string path)
{
    var model = HRStateModel.GetInstance();
    
    // Get views
    var sequenceDiagramViews = new StateMachineViewsFactory(
        model,
        Assembly.GetAssembly(typeof(AbsenceStateMachinePlantUmlViewDefinition))!).GetViews();
    
    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/StateMachines");
    
    // Generate views
    var fileSystemOutput = new FileSystemPlantUmlStateMachineDiagramViewOutput<StateMachineView>(componentsModelPath);
    new PlantUmlStateMachineViewGenerator(fileSystemOutput).Generate(sequenceDiagramViews);
}

void GenerateAsciiDocStateMachineTableViews(string path)
{
    var model = HRStateModel.GetInstance();
    
    // Get views
    var sequenceDiagramViews = new StateMachineAsciiDocTableViewsFactory(
        model,
        Assembly.GetAssembly(typeof(AbsenceStateMachineAsciiDocTableViewDefinition))!).GetViews();
    
    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/StateMachines");
    
    // Generate views
    var fileSystemOutput = new FileSystemAsciiDocStateMachineTableViewOutput<StateMachineAsciiDocTableView>(componentsModelPath);
    new StateMachineAsciiDocTableViewGenerator(fileSystemOutput).Generate(sequenceDiagramViews);
}

void GenerateMermaidEventsFlowViews(string path)
{
    var model = HREventsFlowModel.GetInstance();
    
    // Get views
    var views = new MermaidEventsFlowViewsFactory(
        model,
        Assembly.GetAssembly(typeof(HREventsFlowViewDefinition))!).Views;
    
    // Set views path
    var viewsPath = Path.Combine(path, "Models/EventsFlows");
    
    // Generate views
    var fileSystemOutput = new FileSystemMermaidEventsFlowViewOutput<MermaidEventFlowsView>(viewsPath);
    new MermaidEventsFlowDiagramViewGenerator(fileSystemOutput).Generate(views);
}