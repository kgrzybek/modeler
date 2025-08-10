// See https://aka.ms/new-console-template for more information

using System.Reflection;
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
using Modeler.DataModel.PostgreSQL.Views.Markdown;
using Modeler.DataModel.PostgreSQL.Views.PlantUml;
using Modeler.DataModel.PostgreSQL.Views.Mermaid;
using Modeler.DataModel.PostgreSQL.Views.SQL.Generator;
using Modeler.DataModel.Sample.Structure;
using Modeler.DataModel.Sample.Structure.Tables;
using Modeler.DataModel.Sample.Views.Outputs;
using Modeler.EventsFlowModel.Sample;
using Modeler.EventsFlowModel.Sample.Views.AsciiDoc;
using Modeler.EventsFlowModel.Sample.Views.Mermaid;
using Modeler.EventsFlowModel.Views.Mermaid;
using Modeler.EventsFlowModel.Sample.Views.Markdown;
using Modeler.EventsFlowModel.Views.AsciiDoc;
using Modeler.EventsFlowModel.Views.Markdown;
using Modeler.Full.Sample;
using Modeler.Full.Sample.Apis;
using Modeler.Full.Sample.Apis.Views.AsciiDoc;
using Modeler.Full.Sample.Apis.Views.OpenApi;
using Modeler.Full.Sample.Components.Views;
using Modeler.Full.Sample.Components.Views.AsciiDoc;
using Modeler.Full.Sample.Components.Views.AsciiDoc.Details;
using Modeler.Full.Sample.Components.Views.Outputs;
using Modeler.Full.Sample.Components.Views.Outputs.Markdown;
using Modeler.Full.Sample.Sequences;
using Modeler.Full.Sample.Sequences.Views;
using Modeler.Full.Sample.Sequences.Views.Layouts;
using Modeler.Full.Sample.Sequences.Views.Outputs;
using Modeler.Full.Sample.Sequences.Views.Translations;
using Modeler.SequenceModel.Views.Mermaid;
using Modeler.SequenceModel.Views.PlantUml;
using Modeler.SequenceModel.Views.Shared;
using Modeler.StateModel.Sample.Models;
using Modeler.StateModel.Sample.Views.AsciiDoc;
using Modeler.StateModel.Sample.Views.PlantUml;
using Modeler.StateModel.Sample.Views.Markdown;
using Modeler.StateModel.Views.AsciiDoc;
using Modeler.StateModel.Views.Markdown;
using Modeler.StateModel.Views.PlantUml;
using Modeler.RestApiModel.Sample.Models;
using Modeler.RestApiModel.Sample.Views.AsciiDoc;
using Modeler.RestApiModel.Sample.Views.AsciiDoc.Outputs;
using Modeler.RestApiModel.Views.AsciiDoc;
using Modeler.RestApiModel.Sample.Views.OpenApi;
using Modeler.RestApiModel.Sample.Views.OpenApi.Outputs;
using Modeler.RestApiModel.Views.OpenApi;
using MermaidClassDiagramViewGenerator = Modeler.ConceptualModel.Views.Mermaid.MermaidClassDiagramViewGenerator;
using SystemComponentsModel = Modeler.Full.Sample.Components.SystemComponentsModel;

if (args.Length != 1)
{
    throw new Exception("Provide path to documentation output directory");
}

var documentationPath = args[0];

Console.WriteLine($"Documentation generation to {documentationPath} started.");

// GenerateConceptualModels(documentationPath);
//
// GenerateDataModels(documentationPath);
//

var elementsRegistry = ElementsRegistry.GetInstance();
elementsRegistry.RegisterElements();

var modelsRegistry = ModelsRegistry.GetInstance();
modelsRegistry.RegisterModels(elementsRegistry);

var viewsRegistry = ViewsRegistry.GetInstance();
viewsRegistry.RegisterViews(modelsRegistry);

GenerateSequenceModels(documentationPath);

GenerateComponentsModels(documentationPath);

GenerateAsciiDocRestApiViews(documentationPath);
GenerateOpenApiRestApiViews(documentationPath);

// GeneratePlantUmlStateMachineViews(documentationPath);
//
// GenerateAsciiDocStateMachineTableViews(documentationPath);
//
// GenerateMarkdownStateMachineTableViews(documentationPath);
//
// GenerateMermaidEventsFlowViews(documentationPath);
// GenerateMarkdownEventsFlowViews(documentationPath);
// GenerateAsciiDocEventsFlowViews(documentationPath);


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

    var mermaidDataModelViewsFactory = new MermaidDataModelViewsFactory(model);
    mermaidDataModelViewsFactory.Initialize(Assembly.GetAssembly(typeof(EmployeesTable))!);
    MermaidDataModelGenerator.Generate(
        path,
        model,
        4,
        mermaidDataModelViewsFactory.Views,
        viewTranslator);

    // Generate ascii doc tables
    DataModelAsciiDocGenerator.Generate(dataModelPath, "organizations", model, viewTranslator);

    // Generate markdown tables
    DataModelMarkdownGenerator.Generate(dataModelPath, "organizations", model, viewTranslator);
}

void GenerateSequenceModels(string path)
{
    // Get views
    var sequenceDiagramViews = viewsRegistry.GetElements<SequenceDiagramView>();
    
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
    var systemComponentsModel = modelsRegistry.GetModel<SystemComponentsModel>();
    
    // Get views
    var componentDiagramViews = viewsRegistry.GetElements<ComponentsDiagramView>();
    
    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/Components");
    
    // Generate PlantUML views
    var fileSystemOutput = new FileSystemPlantUmlComponentsDiagramViewOutput<ComponentsDiagramView>(componentsModelPath);
    new PlantComponentsDiagramViewGenerator(systemComponentsModel, fileSystemOutput, new ComponentsDiagramDefaultViewLayout()).Generate(componentDiagramViews);
    
    // Generate AsciiDoc components list view
    var fileSystemAsciiDocComponentsListTableViewOutput = new FileSystemAsciiDocComponentsListTableViewOutput(componentsModelPath);
    new AsciiDocComponentsListTableViewGenerator(systemComponentsModel, fileSystemAsciiDocComponentsListTableViewOutput).Generate();
    
    // Generate AsciiDoc components details views
    var asciiDocDetailsViews = viewsRegistry.GetElements<AsciiDocComponentDetailsView>();
    var fileSystemAsciiDocComponentsDetailsViewOutput = new FileSystemAsciiDocComponentsDetailsViewOutput<AsciiDocComponentDetailsView>(componentsModelPath);
    new AsciiDocComponentsDetailsViewsGenerator(systemComponentsModel, fileSystemAsciiDocComponentsDetailsViewOutput).Generate(asciiDocDetailsViews);

    // Generate Markdown components list view
    var fileSystemMarkdownComponentsListTableViewOutput = new FileSystemMarkdownComponentsListTableViewOutput(componentsModelPath);
    new MarkdownComponentsListTableViewGenerator(systemComponentsModel, fileSystemMarkdownComponentsListTableViewOutput).Generate();

    // Generate Markdown components details views
    var markdownDetailsViews = viewsRegistry.GetElements<MarkdownComponentDetailsView>();
    var fileSystemMarkdownComponentsDetailsViewOutput = new FileSystemMarkdownComponentsDetailsViewOutput<MarkdownComponentDetailsView>(componentsModelPath);
    new MarkdownComponentsDetailsViewsGenerator(systemComponentsModel, fileSystemMarkdownComponentsDetailsViewOutput).Generate(markdownDetailsViews);
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

void GenerateMarkdownStateMachineTableViews(string path)
{
    var model = HRStateModel.GetInstance();

    // Get views
    var views = new StateMachineMarkdownTableViewsFactory(
        model,
        Assembly.GetAssembly(typeof(AbsenceStateMachineMarkdownTableViewDefinition))!).GetViews();

    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/StateMachines");

    // Generate views
    var fileSystemOutput = new FileSystemMarkdownStateMachineTableViewOutput<StateMachineMarkdownTableView>(componentsModelPath);
    new StateMachineMarkdownTableViewGenerator(fileSystemOutput).Generate(views);
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

void GenerateMarkdownEventsFlowViews(string path)
{
    var model = HREventsFlowModel.GetInstance();

    var views = new MarkdownEventsFlowViewsFactory(
        model,
        Assembly.GetAssembly(typeof(HREventsFlowMarkdownViewDefinition))!).Views;

    var viewsPath = Path.Combine(path, "Models/EventsFlows");

    var fileSystemOutput = new FileSystemMarkdownEventsFlowViewOutput<MarkdownEventFlowsView>(viewsPath);
    new MarkdownEventsFlowViewGenerator(fileSystemOutput).Generate(views);
}

void GenerateAsciiDocEventsFlowViews(string path)
{
    var model = HREventsFlowModel.GetInstance();

    var views = new AsciiDocEventsFlowViewsFactory(
        model,
        Assembly.GetAssembly(typeof(HREventsFlowAsciiDocViewDefinition))!).Views;

    var viewsPath = Path.Combine(path, "Models/EventsFlows");

    var fileSystemOutput = new FileSystemAsciiDocEventsFlowViewOutput<AsciiDocEventFlowsView>(viewsPath);
    new AsciiDocEventsFlowViewGenerator(fileSystemOutput).Generate(views);
}

void GenerateAsciiDocRestApiViews(string path)
{
    var model = ElementsRegistry.GetInstance().GetElement<HRRestApiModel>();

    var endpointsViews = new AsciiDocEndpointsViewsFactory(
        model,
        Assembly.GetAssembly(typeof(EndpointsAsciiDocViewDefinition))!).Views;

    var apiModelViews = new AsciiDocApiModelsViewsFactory(
        model,
        Assembly.GetAssembly(typeof(ApiModelsAsciiDocViewDefinition))!).Views;

    var viewsPath = Path.Combine(path, "Models/RestApi");

    var endpointsOutput = new FileSystemAsciiDocRestApiViewOutput<AsciiDocEndpointsView>(viewsPath);
    new AsciiDocEndpointsViewGenerator(endpointsOutput).Generate(endpointsViews);

    var modelsOutput = new FileSystemAsciiDocRestApiViewOutput<AsciiDocApiModelsView>(viewsPath);
    new AsciiDocApiModelsViewGenerator(modelsOutput).Generate(apiModelViews);
}

void GenerateOpenApiRestApiViews(string path)
{
    var model = ElementsRegistry.GetInstance().GetElement<HRRestApiModel>();
    var views = new OpenApiViewsFactory(
        model,
        Assembly.GetAssembly(typeof(OpenApiJsonViewDefinition))!).Views;

    var viewsPath = Path.Combine(path, "Models/RestApi");

    var output = new FileSystemOpenApiRestApiViewOutput<OpenApiView>(viewsPath);

    var jsonViews = views.Where(v => v.Id == OpenApiJsonViewDefinition.Id).ToList();
    var yamlViews = views.Where(v => v.Id == OpenApiYamlViewDefinition.Id).ToList();

    new OpenApiViewGenerator(output).Generate(jsonViews);
    new OpenApiYamlViewGenerator(output).Generate(yamlViews);
}
