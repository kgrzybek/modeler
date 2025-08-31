// See https://aka.ms/new-console-template for more information

using Modeler.Full.Sample;
using Modeler.Full.Sample.Apis.Views.AsciiDoc;
using Modeler.Full.Sample.Apis.Views.OpenApi.Json;
using Modeler.Full.Sample.Apis.Views.OpenApi.Yaml;
using Modeler.Full.Sample.Components.Views.ComponentsDiagram.PlantUml;
using Modeler.Full.Sample.Components.Views.Details.AsciiDoc;
using Modeler.Full.Sample.Components.Views.Details.Markdown;
using Modeler.Full.Sample.Conceptual.Concepts;
using Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;
using Modeler.Full.Sample.Conceptual.Views.ConceptDetails.Markdown;
using Modeler.Full.Sample.Conceptual.Views.ConceptDiagrams;
using Modeler.Full.Sample.Conceptual.Views.Translations;
using Modeler.Full.Sample.Data.Views.SchemaDetails;
using Modeler.Full.Sample.Data.Views.Sql;
using Modeler.Full.Sample.EventsFlow.Views.EventsFlowDiagrams.Mermaid;
using Modeler.Full.Sample.EventsFlow.Views.TableList.AsciiDoc;
using Modeler.Full.Sample.EventsFlow.Views.TableList.Markdown;
using Modeler.Full.Sample.Messaging.HRBroker;
using Modeler.Full.Sample.Sequences.Views.Layouts;
using Modeler.Full.Sample.Sequences.Views.Outputs;
using Modeler.Full.Sample.Sequences.Views.Translations;
using Modeler.Full.Sample.State.Views.PlantUml;
using Modeler.Full.Sample.State.Views.StateMachineTable.AsciiDoc;
using Modeler.Full.Sample.State.Views.StateMachineTable.Markdown;
using Modeler.Views.Common;
using Modeler.Views.Components.ComponentsDiagram;
using Modeler.Views.Components.Details.AsciiDoc;
using Modeler.Views.Components.Details.Markdown;
using Modeler.Views.Components.ListTable.AsciiDoc;
using Modeler.Views.Components.ListTable.Markdown;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;
using Modeler.Views.Conceptual.ConceptDetails.Markdown;
using Modeler.Views.Conceptual.ConceptDetails.Shared;
using Modeler.Views.Conceptual.ConceptDiagrams.PlantUml;
using Modeler.Views.Data.DataModelDiagrams.Mermaid;
using Modeler.Views.Data.DataModelDiagrams.PlantUml;
using Modeler.Views.Data.Shared;
using Modeler.Views.Data.Sql;
using Modeler.Views.Data.Structure.AsciiDoc;
using Modeler.Views.Data.Structure.Markdown;
using Modeler.Views.EventsFlow.Diagram.Mermaid;
using Modeler.Views.EventsFlow.ItemsList.AsciiDoc;
using Modeler.Views.EventsFlow.ItemsList.Markdown;
using Modeler.Views.Messaging.BrokerMessagesList.AsciiDoc;
using Modeler.Views.RestApi.ApiModelsList.AsciiDoc;
using Modeler.Views.RestApi.EndpointsList.AsciiDoc;
using Modeler.Views.RestApi.OpenApi.Json;
using Modeler.Views.RestApi.OpenApi.Shared;
using Modeler.Views.RestApi.OpenApi.Yaml;
using Modeler.Views.Sequence.Diagram.Mermaid;
using Modeler.Views.Sequence.Diagram.PlantUml;
using Modeler.Views.Sequence.Diagram.Shared;
using Modeler.Views.StateMachine.Diagram.PlantUml;
using Modeler.Views.StateMachine.Table.AsciiDoc;
using Modeler.Views.StateMachine.Table.Markdown;
using HRDataModel = Modeler.Full.Sample.Data.Structure.HRDataModel;
using MermaidClassDiagramViewGenerator = Modeler.Views.Conceptual.ConceptDiagrams.Mermaid.MermaidClassDiagramViewGenerator;
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
viewsRegistry.RegisterViews(modelsRegistry, elementsRegistry);

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

GenerateMessagingViews(documentationPath);

Console.WriteLine("Documentation generated.");


void GenerateConceptualModels(string path)
{
    // Get model
    var model = modelsRegistry.GetModel<OrganizationStructureConceptualModel>();

    // class diagram views
    var classDiagramViews = viewsRegistry.GetElements<ConceptsClassDiagramView>();

    // Views translations
    var viewTranslator = new ViewTranslator();

    // Path for models
    var modelsPath = Path.Combine(path, "Models/Conceptual");

    // PlantUML
    new PlantUmlClassDiagramViewGenerator(
        model,
        4,
        viewTranslator,
        new PlantUmlConceptDiagramViewFileSystemViewsOutput(modelsPath, viewsRegistry)).Generate(classDiagramViews);

    // Mermaid
    new MermaidClassDiagramViewGenerator(
        model,
        4,
        viewTranslator,
        new MermaidConceptDiagramViewFileSystemViewsOutput(modelsPath, viewsRegistry)).Generate(classDiagramViews);

    // AsciiDoc
    var asciDocViews = viewsRegistry.GetElements<AsciiDocConceptDetailsView>();
    new AsciiDocConceptDetailsViewsGenerator(
        model,
        viewTranslator,
        new AsciiDocConceptDetailsFileSystemViewsOutput(modelsPath, viewsRegistry),
        new AsciiDocConceptDetailsViewTranslationDictionary()).Generate(asciDocViews);

    // Markdown
    var markdownViews = viewsRegistry.GetElements<MarkdownConceptDetailsView>();
    new MarkdownConceptDetailsViewsGenerator(
        model,
        viewTranslator,
        new MarkdownConceptDetailsFileSystemViewsOutput(modelsPath, viewsRegistry),
        new MarkdownViewConceptDetailsTranslationDictionary()).Generate(markdownViews);
}

void GenerateMessagingViews(string path)
{
    var model = modelsRegistry.GetModel<HRBrokerModel>();
    var dataModelPath = Path.Combine(path, "Models/Messaging");
    IViewOutput output = new FileSystemViewOutput(dataModelPath, "MessagesList.adoc");
    AsciiDocBrokerMessagesListGenerator.Generate(model, output);
}

void GenerateDataModels(string path)
{
    // Get model
    var model = modelsRegistry.GetModel<HRDataModel>();
    
    // Generate database scripts
    var dataModelPath = Path.Combine(path, "Models/Data");
    var views = viewsRegistry.GetElements<SqlStructureElementView>();
    new PostgreSqlStructureViewsGenerator(new SqlFileSystemViewsOutput(dataModelPath, viewsRegistry)).Generate(views);

    // Generate data model diagrams
    var plantUmlDataViews = viewsRegistry.GetElements<PlantUmlDataModelView>();
    var viewTranslator = new Modeler.Full.Sample.Data.Views.Translations.ViewTranslator();
    
    PlantUmlDataModelGenerator.Generate(
        model,
        4,
        plantUmlDataViews,
        viewTranslator,
        new FileSystemViewOutput(dataModelPath, "Organizations_data_model.puml"));

    var mermaidUmlDataViews = viewsRegistry.GetElements<MermaidDataModelView>();
    MermaidDataModelGenerator.Generate(
        model,
        4,
        mermaidUmlDataViews,
        viewTranslator,
        new FileSystemViewOutput(dataModelPath, "Organizations_data_model.mmd"));

    var schemaViews = viewsRegistry.GetElements<DataModelSchemaDetailsView>();
    // Generate ascii doc tables

    DataModelAsciiDocGenerator.Generate(
        "organizations", 
        model, 
        viewTranslator, 
        new AsciiDocSchemaDetailsFileSystemViewsOutput(dataModelPath, viewsRegistry), 
        schemaViews);

    // Generate markdown tables
    DataModelMarkdownGenerator.Generate(
        "organizations", 
        model, 
        viewTranslator,
        new MarkdownSchemaDetailsFileSystemViewsOutput(dataModelPath, viewsRegistry),
        schemaViews);
}

void GenerateSequenceModels(string path)
{
    // Get views
    var sequenceDiagramViews = viewsRegistry.GetElements<SequenceDiagramView>();
    
    // Set views path
    var sequencesModelPath = Path.Combine(path, "Models/Sequences");
    
    // Generate views
    
    var viewTranslator = new SequenceDiagramViewTranslator();
    var viewLayout = new DefaultViewLayout();
    
    // Generate PlantUml views
    var fileSystemOutput = new PlantUmlSequenceDiagramsViewFileSystemViewsOutput(sequencesModelPath, viewsRegistry);
    new PlantUmlSequenceDiagramViewGenerator(fileSystemOutput, viewTranslator, viewLayout).Generate(sequenceDiagramViews);
    
    // Generate Mermaid views
    var mermaidFilesOutput = new MermaidSequenceDiagramsViewFileSystemViewsOutput(sequencesModelPath, viewsRegistry);
    new MermaidSequenceDiagramViewGenerator(mermaidFilesOutput, viewTranslator).Generate(sequenceDiagramViews);
}

void GenerateComponentsModels(string path)
{
    var systemComponentsModel = modelsRegistry.GetModel<SystemComponentsModel>();
    
    // Get views
    var componentDiagramViews = viewsRegistry.GetElements<PlantUmlComponentsDiagramView>();
    
    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/Components");
    
    // Generate PlantUML views
    var fileSystemOutput = new PlantUmlComponentsDiagramViewFileSystemViewsOutput(componentsModelPath, viewsRegistry);
    new PlantComponentsDiagramViewGenerator(systemComponentsModel, fileSystemOutput, new ComponentsDiagramDefaultViewLayout()).Generate(componentDiagramViews);
    
    // Generate AsciiDoc components list view
    var fileSystemAsciiDocComponentsListTableViewOutput = new FileSystemViewOutput(componentsModelPath, "ComponentsList_full.adoc");
    new AsciiDocComponentsListTableViewGenerator(systemComponentsModel, fileSystemAsciiDocComponentsListTableViewOutput).Generate();
    
    // Generate AsciiDoc components details views
    var asciiDocDetailsViews = viewsRegistry.GetElements<AsciiDocComponentDetailsView>();
    var fileSystemAsciiDocComponentsDetailsViewOutput = new AsciiDocComponentsDetailsFileSystemViewsOutput(componentsModelPath, viewsRegistry);
    new AsciiDocComponentsDetailsViewsGenerator(systemComponentsModel, fileSystemAsciiDocComponentsDetailsViewOutput).Generate(asciiDocDetailsViews);

    // Generate Markdown components list view
    var fileSystemMarkdownComponentsListTableViewOutput = new FileSystemViewOutput(componentsModelPath, "ComponentsList_full.md");
    new MarkdownComponentsListTableViewGenerator(systemComponentsModel, fileSystemMarkdownComponentsListTableViewOutput).Generate();

    // Generate Markdown components details views
    var markdownDetailsViews = viewsRegistry.GetElements<MarkdownComponentDetailsView>();
    var fileSystemMarkdownComponentsDetailsViewOutput = new MarkdownComponentsDetailsFileSystemViewsOutput(componentsModelPath, viewsRegistry);
    new MarkdownComponentsDetailsViewsGenerator(systemComponentsModel, fileSystemMarkdownComponentsDetailsViewOutput).Generate(markdownDetailsViews);
}

void GeneratePlantUmlStateMachineViews(string path)
{
    // Get views
    var stateMachineViews = viewsRegistry.GetElements<PlantUmlStateMachineDiagramView>();
    
    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/StateMachines");
    
    // Generate views
    var fileSystemOutput = new PlantUmlStateMachineDiagramsFileSystemViewsOutput(componentsModelPath, viewsRegistry);
    new PlantUmlStateMachineViewGenerator(fileSystemOutput).Generate(stateMachineViews);
}

void GenerateAsciiDocStateMachineTableViews(string path)
{
    // Get views
    var stateMachineViews = viewsRegistry.GetElements<StateMachineAsciiDocTableView>();
    
    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/StateMachines");
    
    // Generate views
    var fileSystemOutput = new AsciiDocStateMachineTableFileSystemViewsOutput(componentsModelPath, viewsRegistry);
    new StateMachineAsciiDocTableViewGenerator(fileSystemOutput).Generate(stateMachineViews);
}

void GenerateMarkdownStateMachineTableViews(string path)
{
    // Get views
    var stateMachineViews = viewsRegistry.GetElements<StateMachineMarkdownTableView>();

    // Set views path
    var componentsModelPath = Path.Combine(path, "Models/StateMachines");

    // Generate views
    var fileSystemOutput = new MarkdownStateMachineTableFileSystemViewsOutput(componentsModelPath, viewsRegistry);
    new StateMachineMarkdownTableViewGenerator(fileSystemOutput).Generate(stateMachineViews);
}

void GenerateMermaidEventsFlowViews(string path)
{
    // Get views
    var views = viewsRegistry.GetElements<MermaidEventFlowsDiagramView>();
    
    // Set views path
    var viewsPath = Path.Combine(path, "Models/EventsFlows");
    
    // Generate views
    var fileSystemOutput = new FileSystemMermaidEventsFlowDiagramViewOutput(viewsPath, viewsRegistry);
    new MermaidEventsFlowDiagramViewGenerator(fileSystemOutput).Generate(views);
}

void GenerateMarkdownEventsFlowViews(string path)
{
    var views = viewsRegistry.GetElements<MarkdownEventFlowsView>();

    var viewsPath = Path.Combine(path, "Models/EventsFlows");

    var fileSystemOutput = new FileSystemMarkdownEventsFlowViewOutput(viewsPath, viewsRegistry);
    new MarkdownEventsFlowViewGenerator(fileSystemOutput).Generate(views);
}

void GenerateAsciiDocEventsFlowViews(string path)
{
    var views = viewsRegistry.GetElements<AsciiDocEventFlowsView>();

    var viewsPath = Path.Combine(path, "Models/EventsFlows");

    var fileSystemOutput = new FileSystemAsciiDocEventsFlowViewOutput(viewsPath, viewsRegistry);
    new AsciiDocEventsFlowViewGenerator(fileSystemOutput).Generate(views);
}

void GenerateAsciiDocRestApiViews(string path)
{
    var endpointsViews = viewsRegistry.GetElements<AsciiDocEndpointsView>();
    
    var apiModelViews = viewsRegistry.GetElements<AsciiDocApiModelsView>();

    var viewsPath = Path.Combine(path, "Models/RestApi");

    var endpointsOutput = new AsciiDocHRApiEndpointsFileSystemViewsOutput(viewsPath, viewsRegistry);
    new AsciiDocEndpointsViewGenerator(endpointsOutput).Generate(endpointsViews);

    var modelsOutput = new AsciiDocHRApiApiModelsFileSystemViewsOutput(viewsPath, viewsRegistry);
    new AsciiDocApiModelsViewGenerator(modelsOutput).Generate(apiModelViews);
}

void GenerateOpenApiRestApiViews(string path)
{
    var viewsPath = Path.Combine(path, "Models/RestApi");

    var views = viewsRegistry.GetElements<OpenApiView>();
    new OpenApiViewGenerator(new JsonOpenApiFileSystemViewsOutput(viewsPath, viewsRegistry)).Generate(views);
    new OpenApiYamlViewGenerator(new YamlApiFileSystemViewsOutput(viewsPath, viewsRegistry)).Generate(views);
}