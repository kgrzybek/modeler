// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Modeler.ComponentsModel.Views.AsciiDoc;
using Modeler.ComponentsModel.Views.AsciiDoc.Details;
using Modeler.ComponentsModel.Views.Markdown;
using Modeler.ComponentsModel.Views.Markdown.Details;
using Modeler.ComponentsModel.Views.PlantUml;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.ConceptualModel.Views.AsciiDoc;
using Modeler.ConceptualModel.Views.PlantUml;
using Modeler.ConceptualModel.Views.Shared;
using Modeler.DataModel.PostgreSQL.Views.AsciiDoc;
using Modeler.DataModel.PostgreSQL.Views.Markdown;
using Modeler.DataModel.PostgreSQL.Views.PlantUml;
using Modeler.DataModel.PostgreSQL.Views.Mermaid;
using Modeler.DataModel.PostgreSQL.Views.SQL.Generator;
using Modeler.EventsFlowModel.Views.Mermaid;
using Modeler.EventsFlowModel.Views.AsciiDoc;
using Modeler.EventsFlowModel.Views.Markdown;
using Modeler.Full.Sample;
using Modeler.Full.Sample.Apis;
using Modeler.Full.Sample.Apis.Views.AsciiDoc;
using Modeler.Full.Sample.Apis.Views.AsciiDoc.Outputs;
using Modeler.Full.Sample.Apis.Views.OpenApi;
using Modeler.Full.Sample.Apis.Views.OpenApi.Outputs;
using Modeler.Full.Sample.Components.Views;
using Modeler.Full.Sample.Components.Views.AsciiDoc;
using Modeler.Full.Sample.Components.Views.AsciiDoc.Details;
using Modeler.Full.Sample.Components.Views.Outputs;
using Modeler.Full.Sample.Components.Views.Outputs.Markdown;
using Modeler.Full.Sample.Conceptual.Concepts;
using Modeler.Full.Sample.Conceptual.Views.Outputs;
using Modeler.Full.Sample.Conceptual.Views.Outputs.Markdown;
using Modeler.Full.Sample.Conceptual.Views.Translations;
using Modeler.Full.Sample.Data.Views.Outputs;
using Modeler.Full.Sample.EventsFlow;
using Modeler.Full.Sample.EventsFlow.Views.AsciiDoc;
using Modeler.Full.Sample.EventsFlow.Views.Markdown;
using Modeler.Full.Sample.EventsFlow.Views.Mermaid;
using Modeler.Full.Sample.Sequences.Views.Layouts;
using Modeler.Full.Sample.Sequences.Views.Outputs;
using Modeler.Full.Sample.Sequences.Views.Translations;
using Modeler.Full.Sample.State.Views.AsciiDoc;
using Modeler.Full.Sample.State.Views.Markdown;
using Modeler.Full.Sample.State.Views.PlantUml;
using Modeler.SequenceModel.Views.Mermaid;
using Modeler.SequenceModel.Views.PlantUml;
using Modeler.SequenceModel.Views.Shared;
using Modeler.StateModel.Views.AsciiDoc;
using Modeler.StateModel.Views.Markdown;
using Modeler.StateModel.Views.PlantUml;
using Modeler.RestApiModel.Views.AsciiDoc;
using Modeler.RestApiModel.Views.OpenApi;
using HRDataModel = Modeler.Full.Sample.Data.Structure.HRDataModel;
using MermaidClassDiagramViewGenerator = Modeler.ConceptualModel.Views.Mermaid.MermaidClassDiagramViewGenerator;
using SystemComponentsModel = Modeler.Full.Sample.Components.SystemComponentsModel;

if (args.Length != 1)
{
    throw new Exception("Provide path to documentation output directory");
}

var documentationPath = args[0];

Console.WriteLine($"Documentation generation to {documentationPath} started.");

var elementsRegistry = ElementsRegistry.GetInstance();
elementsRegistry.RegisterElements();

var modelsRegistry = new ModelsRegistry();
modelsRegistry.RegisterModels(elementsRegistry);

var viewsRegistry = ViewsRegistry.GetInstance();
viewsRegistry.RegisterViews(modelsRegistry);

GenerateDataModels(documentationPath);

GenerateSequenceModels(documentationPath);

GenerateComponentsModels(documentationPath);

GenerateAsciiDocRestApiViews(documentationPath);

GenerateOpenApiRestApiViews(documentationPath);

GenerateConceptualModels(documentationPath);

GeneratePlantUmlStateMachineViews(documentationPath);

GenerateAsciiDocStateMachineTableViews(documentationPath);

GenerateMarkdownStateMachineTableViews(documentationPath);

GenerateMermaidEventsFlowViews(documentationPath);
GenerateMarkdownEventsFlowViews(documentationPath);
GenerateAsciiDocEventsFlowViews(documentationPath);

Console.WriteLine("Documentation generated.");


void GenerateConceptualModels(string path)
{
    // Get model
    var model = modelsRegistry.GetModel<OrganizationStructureConceptualModel>();

    // class diagram views
    var classDiagramViews = viewsRegistry.GetElements<ClassDiagramView>();

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
    var asciDocViews = viewsRegistry.GetElements<AsciiDocView>();
    new AsciiDocViewsGenerator(
        model,
        viewTranslator,
        new FileSystemAsciiDocViewOutput<AsciiDocView>(modelsPath),
        new AsciiDocViewTranslationDictionary()).Generate(asciDocViews);

    // Markdown
    var markdownViews = viewsRegistry.GetElements<MarkdownView>();
    new MarkdownViewsGenerator(
        model,
        viewTranslator,
        new FileSystemMarkdownViewOutput<MarkdownView>(modelsPath),
        new MarkdownViewTranslationDictionary()).Generate(markdownViews);
}

void GenerateDataModels(string path)
{
    // Get model
    var model = modelsRegistry.GetModel<HRDataModel>();
    
    // Generate database scripts
    var dataModelPath = Path.Combine(path, "Models/Data");
    var fileSystemOutput = new FileSystemOutput(dataModelPath);
    new PostgreSqlStructureViewsGenerator(model, fileSystemOutput).Generate();

    // Generate data model diagrams
    var plantUmlDataViews = viewsRegistry.GetElements<PlantUmlDataModelView>();
    var viewTranslator = new Modeler.DataModel.Sample.Views.Translations.ViewTranslator();
    
    PlantUmlDataModelGenerator.Generate(
        path,
        model,
        4,
        plantUmlDataViews,
        viewTranslator);

    var mermaidUmlDataViews = viewsRegistry.GetElements<MermaidDataModelView>();
    MermaidDataModelGenerator.Generate(
        path,
        model,
        4,
        mermaidUmlDataViews,
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
    // Get views
    var stateMachineViews = viewsRegistry.GetElements<StateMachineView>();
    
    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/StateMachines");
    
    // Generate views
    var fileSystemOutput = new FileSystemPlantUmlStateMachineDiagramViewOutput<StateMachineView>(componentsModelPath);
    new PlantUmlStateMachineViewGenerator(fileSystemOutput).Generate(stateMachineViews);
}

void GenerateAsciiDocStateMachineTableViews(string path)
{
    // Get views
    var stateMachineViews = viewsRegistry.GetElements<StateMachineAsciiDocTableView>();
    
    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/StateMachines");
    
    // Generate views
    var fileSystemOutput = new FileSystemAsciiDocStateMachineTableViewOutput<StateMachineAsciiDocTableView>(componentsModelPath);
    new StateMachineAsciiDocTableViewGenerator(fileSystemOutput).Generate(stateMachineViews);
}

void GenerateMarkdownStateMachineTableViews(string path)
{
    // Get views
    var stateMachineViews = viewsRegistry.GetElements<StateMachineMarkdownTableView>();

    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/StateMachines");

    // Generate views
    var fileSystemOutput = new FileSystemMarkdownStateMachineTableViewOutput<StateMachineMarkdownTableView>(componentsModelPath);
    new StateMachineMarkdownTableViewGenerator(fileSystemOutput).Generate(stateMachineViews);
}

void GenerateMermaidEventsFlowViews(string path)
{
    // Get views
    var views = viewsRegistry.GetElements<MermaidEventFlowsView>();
    
    // Set views path
    var viewsPath = Path.Combine(path, "Models/EventsFlows");
    
    // Generate views
    var fileSystemOutput = new FileSystemMermaidEventsFlowViewOutput<MermaidEventFlowsView>(viewsPath);
    new MermaidEventsFlowDiagramViewGenerator(fileSystemOutput).Generate(views);
}

void GenerateMarkdownEventsFlowViews(string path)
{
    var views = viewsRegistry.GetElements<MarkdownEventFlowsView>();

    var viewsPath = Path.Combine(path, "Models/EventsFlows");

    var fileSystemOutput = new FileSystemMarkdownEventsFlowViewOutput<MarkdownEventFlowsView>(viewsPath);
    new MarkdownEventsFlowViewGenerator(fileSystemOutput).Generate(views);
}

void GenerateAsciiDocEventsFlowViews(string path)
{
    var views = viewsRegistry.GetElements<AsciiDocEventFlowsView>();

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
