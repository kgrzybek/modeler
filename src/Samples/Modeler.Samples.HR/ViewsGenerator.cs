using Modeler.Models.Common.Elements;
using Modeler.Samples.HR.Components;
using Modeler.Samples.HR.Components.HRBroker;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.ApiModelsList.AsciiDoc;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.EndpointsList.AsciiDoc;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.OpenApi.Json;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.OpenApi.Yaml;
using Modeler.Samples.HR.Components.System.Database;
using Modeler.Samples.HR.Components.System.Database.Views.SchemaDetails.AsciiDoc;
using Modeler.Samples.HR.Components.System.Database.Views.SchemaDetails.Markdown;
using Modeler.Samples.HR.Components.System.Database.Views.Sql;
using Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;
using Modeler.Samples.HR.Components.Views.Details.AsciiDoc;
using Modeler.Samples.HR.Components.Views.Details.Markdown;
using Modeler.Samples.HR.Conceptual.Concepts;
using Modeler.Samples.HR.Conceptual.Views.ConceptDetails.AsciiDoc;
using Modeler.Samples.HR.Conceptual.Views.ConceptDetails.Markdown;
using Modeler.Samples.HR.Conceptual.Views.ConceptDiagrams;
using Modeler.Samples.HR.Conceptual.Views.ConceptDiagrams.Translations;
using Modeler.Samples.HR.Deployment;
using Modeler.Samples.HR.Deployment.Views.PlantUml;
using Modeler.Samples.HR.EventsFlow.Views.EventsFlowDiagrams.Mermaid;
using Modeler.Samples.HR.EventsFlow.Views.TableList.AsciiDoc;
using Modeler.Samples.HR.EventsFlow.Views.TableList.Markdown;
using Modeler.Samples.HR.Sequences.Views.SequenceDiagrams.Layouts;
using Modeler.Samples.HR.Sequences.Views.SequenceDiagrams.Mermaid;
using Modeler.Samples.HR.Sequences.Views.SequenceDiagrams.PlantUml;
using Modeler.Samples.HR.Sequences.Views.SequenceDiagrams.Translations;
using Modeler.Samples.HR.State.Views.PlantUml;
using Modeler.Samples.HR.State.Views.StateMachineTable.AsciiDoc;
using Modeler.Samples.HR.State.Views.StateMachineTable.Markdown;
using Modeler.Views.Common.Outputs;
using Modeler.Views.Components.Details.AsciiDoc;
using Modeler.Views.Components.Details.Markdown;
using Modeler.Views.Components.Diagram;
using Modeler.Views.Components.ListTable.AsciiDoc;
using Modeler.Views.Components.ListTable.Markdown;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;
using Modeler.Views.Conceptual.ConceptDetails.Markdown;
using Modeler.Views.Conceptual.ConceptDetails.Shared;
using Modeler.Views.Conceptual.ConceptDiagrams.Mermaid;
using Modeler.Views.Conceptual.ConceptDiagrams.PlantUml;
using Modeler.Views.Data.DataModelDiagrams.Mermaid;
using Modeler.Views.Data.DataModelDiagrams.PlantUml;
using Modeler.Views.Data.Diagram.PlantUml;
using Modeler.Views.Data.Shared;
using Modeler.Views.Data.Sql;
using Modeler.Views.Data.Structure.AsciiDoc;
using Modeler.Views.Data.Structure.Markdown;
using Modeler.Views.EventsFlow.Diagram.Mermaid;
using Modeler.Views.EventsFlow.ItemsList.AsciiDoc;
using Modeler.Views.EventsFlow.ItemsList.Markdown;
using Modeler.Views.Deployment.Diagram;
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

namespace Modeler.Samples.HR;

public static class ViewsGenerator
{
    public static void Generate(string documentationPath)
    {
        var elementsRegistry = new ElementsRegistry();
        elementsRegistry.RegisterElements();

        var modelsRegistry = new ModelsRegistry();
        modelsRegistry.RegisterModels(elementsRegistry);

        var viewsRegistry = new ViewsRegistry();
        viewsRegistry.RegisterViews(modelsRegistry, elementsRegistry);

        GenerateDataViews(documentationPath, elementsRegistry, viewsRegistry);

        GenerateSequenceViews(documentationPath, viewsRegistry);

        GenerateComponentsViews(documentationPath, modelsRegistry, viewsRegistry);

        GenerateDeploymentViews(documentationPath, modelsRegistry, viewsRegistry);

        GenerateOpenApiViews(documentationPath, viewsRegistry);

        GenerateConceptualViews(documentationPath, modelsRegistry, viewsRegistry);

        GenerateStateMachineViews(documentationPath, viewsRegistry);

        GenerateEventFlowsViews(documentationPath, viewsRegistry);

        GenerateMessagingViews(documentationPath, elementsRegistry);
    }
    
    private static void GenerateEventFlowsViews(string documentationPath, ViewsRegistry viewsRegistry)
    {
        GenerateMermaidEventsFlowViews(documentationPath, viewsRegistry);
        GenerateMarkdownEventsFlowViews(documentationPath, viewsRegistry);
        GenerateAsciiDocEventsFlowViews(documentationPath, viewsRegistry);
    }

    private static void GenerateOpenApiViews(string documentationPath, ViewsRegistry viewsRegistry)
    {
        GenerateAsciiDocRestApiViews(documentationPath, viewsRegistry);

        GenerateOpenApiRestApiViews(documentationPath, viewsRegistry);
    }
    
    private static void GenerateStateMachineViews(string documentationPath, ViewsRegistry viewsRegistry)
    {
        GeneratePlantUmlStateMachineViews(documentationPath, viewsRegistry);

        GenerateAsciiDocStateMachineTableViews(documentationPath, viewsRegistry);

        GenerateMarkdownStateMachineTableViews(documentationPath, viewsRegistry);
    }

    private static void GenerateConceptualViews(
        string path,
        ModelsRegistry modelsRegistry,
        ViewsRegistry viewsRegistry)
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

    private static void GenerateMessagingViews(
        string path,
        ElementsRegistry elementsRegistry)
    {
        var hrBrokerComponent = elementsRegistry.GetElement<HRBrokerComponent>();
        var dataModelPath = Path.Combine(path, "Models/Messaging");
        IViewOutput output = new FileSystemViewOutput(dataModelPath, "MessagesList.adoc");
        AsciiDocBrokerMessagesListGenerator.Generate(hrBrokerComponent, output);
    }

    private static void GenerateDataViews(
        string path,
        ModelElementsRegistry elementsRegistry,
        ViewsRegistry viewsRegistry)
    {
        // Get model
        var model = elementsRegistry.GetElement<HRDatabaseComponent>();

        // Generate database scripts
        var dataModelPath = Path.Combine(path, "Models/Data");
        var views = viewsRegistry.GetElements<SqlStructureElementView>();
        new PostgreSqlStructureViewsGenerator(new SqlFileSystemViewsOutput(dataModelPath, viewsRegistry))
            .Generate(views);

        // Generate data model diagrams
        var plantUmlDataViews = viewsRegistry.GetElements<PlantUmlDataModelView>();
        var viewTranslator = new Components.System.Database.Views.Translations.ViewTranslator();

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

    private static void GenerateSequenceViews(
        string path,
        ViewsRegistry viewsRegistry)
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
        new PlantUmlSequenceDiagramViewGenerator(fileSystemOutput, viewTranslator, viewLayout).Generate(
            sequenceDiagramViews);

        // Generate Mermaid views
        var mermaidFilesOutput =
            new MermaidSequenceDiagramsViewFileSystemViewsOutput(sequencesModelPath, viewsRegistry);
        new MermaidSequenceDiagramViewGenerator(mermaidFilesOutput, viewTranslator).Generate(sequenceDiagramViews);
    }

    private static void GenerateComponentsViews(string path,
        ModelsRegistry modelsRegistry,
        ViewsRegistry viewsRegistry)
    {
        var systemComponentsModel = modelsRegistry.GetModel<HRSystemComponentsModel>();

        // Get views
        var componentDiagramViews = viewsRegistry.GetElements<PlantUmlComponentsDiagramView>();

        // Set views path
        var componentsModelPath = Path.Combine(path, "Models/Components");

        // Generate PlantUML views
        var fileSystemOutput =
            new PlantUmlComponentsDiagramViewFileSystemViewsOutput(componentsModelPath, viewsRegistry);
        new PlantComponentsDiagramViewGenerator(
            systemComponentsModel, 
            fileSystemOutput,
            new ComponentsDiagramDefaultViewLayout(),
            new ComponentsViewTranslator(),
            new PlantUmlComponentDiagramRelationshipsGenerator()).Generate(componentDiagramViews);

        // Generate AsciiDoc components list view
        var fileSystemAsciiDocComponentsListTableViewOutput =
            new FileSystemViewOutput(componentsModelPath, "ComponentsList_full.adoc");
        new AsciiDocComponentsListTableViewGenerator(systemComponentsModel,
            fileSystemAsciiDocComponentsListTableViewOutput).Generate();

        // Generate AsciiDoc components details views
        var asciiDocDetailsViews = viewsRegistry.GetElements<AsciiDocComponentDetailsView>();
        var fileSystemAsciiDocComponentsDetailsViewOutput =
            new AsciiDocComponentsDetailsFileSystemViewsOutput(componentsModelPath, viewsRegistry);
        new AsciiDocComponentsDetailsViewsGenerator(systemComponentsModel,
            fileSystemAsciiDocComponentsDetailsViewOutput,
            new ComponentsViewTranslator()).Generate(asciiDocDetailsViews);

        // Generate Markdown components list view
        var fileSystemMarkdownComponentsListTableViewOutput =
            new FileSystemViewOutput(componentsModelPath, "ComponentsList_full.md");
        new MarkdownComponentsListTableViewGenerator(systemComponentsModel,
            fileSystemMarkdownComponentsListTableViewOutput).Generate();

        // Generate Markdown components details views
        var markdownDetailsViews = viewsRegistry.GetElements<MarkdownComponentDetailsView>();
        var fileSystemMarkdownComponentsDetailsViewOutput =
            new MarkdownComponentsDetailsFileSystemViewsOutput(componentsModelPath, viewsRegistry);
        new MarkdownComponentsDetailsViewsGenerator(
            systemComponentsModel,
            fileSystemMarkdownComponentsDetailsViewOutput,
            new ComponentsViewTranslator()).Generate(markdownDetailsViews);
    }

    private static void GenerateDeploymentViews(
        string path,
        ModelsRegistry modelsRegistry,
        ViewsRegistry viewsRegistry)
    {
        var deploymentModel = modelsRegistry.GetModel<HRDeploymentModel>();
        var deploymentViews = viewsRegistry.GetElements<PlantUmlDeploymentDiagramView>();

        if (deploymentViews.Count == 0)
        {
            return;
        }

        var deploymentPath = Path.Combine(path, "Models/Deployment");
        var output = new PlantUmlDeploymentDiagramViewFileSystemViewsOutput(deploymentPath, viewsRegistry);

        new PlantDeploymentDiagramViewGenerator(
            deploymentModel,
            output,
            new DeploymentDiagramDefaultViewLayout()).Generate(deploymentViews);
    }

    private static void GeneratePlantUmlStateMachineViews(
        string path,
        ViewsRegistry viewsRegistry)
    {
        // Get views
        var stateMachineViews = viewsRegistry.GetElements<PlantUmlStateMachineDiagramView>();

        // Set views path
        var componentsModelPath = Path.Combine(path, "Models/StateMachines");

        // Generate views
        var fileSystemOutput =
            new PlantUmlStateMachineDiagramsFileSystemViewsOutput(componentsModelPath, viewsRegistry);
        new PlantUmlStateMachineViewGenerator(fileSystemOutput).Generate(stateMachineViews);
    }

    private static void GenerateAsciiDocStateMachineTableViews(
        string path,
        ViewsRegistry viewsRegistry)
    {
        // Get views
        var stateMachineViews = viewsRegistry.GetElements<StateMachineAsciiDocTableView>();

        // Set views path
        var componentsModelPath = Path.Combine(path, "Models/StateMachines");

        // Generate views
        var fileSystemOutput = new AsciiDocStateMachineTableFileSystemViewsOutput(componentsModelPath, viewsRegistry);
        new StateMachineAsciiDocTableViewGenerator(fileSystemOutput).Generate(stateMachineViews);
    }

    private static void GenerateMarkdownStateMachineTableViews(
        string path,
        ViewsRegistry viewsRegistry)
    {
        // Get views
        var stateMachineViews = viewsRegistry.GetElements<StateMachineMarkdownTableView>();

        // Set views path
        var componentsModelPath = Path.Combine(path, "Models/StateMachines");

        // Generate views
        var fileSystemOutput = new MarkdownStateMachineTableFileSystemViewsOutput(componentsModelPath, viewsRegistry);
        new StateMachineMarkdownTableViewGenerator(fileSystemOutput).Generate(stateMachineViews);
    }

    private static void GenerateMermaidEventsFlowViews(
        string path,
        ViewsRegistry viewsRegistry)
    {
        // Get views
        var views = viewsRegistry.GetElements<MermaidEventFlowsDiagramView>();

        // Set views path
        var viewsPath = Path.Combine(path, "Models/EventsFlows");

        // Generate views
        var fileSystemOutput = new FileSystemMermaidEventsFlowDiagramViewOutput(viewsPath, viewsRegistry);
        new MermaidEventsFlowDiagramViewGenerator(fileSystemOutput).Generate(views);
    }

    private static void GenerateMarkdownEventsFlowViews(
        string path,
        ViewsRegistry viewsRegistry)
    {
        var views = viewsRegistry.GetElements<MarkdownEventFlowsView>();

        var viewsPath = Path.Combine(path, "Models/EventsFlows");

        var fileSystemOutput = new FileSystemMarkdownEventsFlowViewOutput(viewsPath, viewsRegistry);
        new MarkdownEventsFlowViewGenerator(fileSystemOutput).Generate(views);
    }

    private static void GenerateAsciiDocEventsFlowViews(
        string path,
        ViewsRegistry viewsRegistry)
    {
        var views = viewsRegistry.GetElements<AsciiDocEventFlowsView>();

        var viewsPath = Path.Combine(path, "Models/EventsFlows");

        var fileSystemOutput = new FileSystemAsciiDocEventsFlowViewOutput(viewsPath, viewsRegistry);
        new AsciiDocEventsFlowViewGenerator(fileSystemOutput).Generate(views);
    }

    private static void GenerateAsciiDocRestApiViews(
        string path,
        ViewsRegistry viewsRegistry)
    {
        var endpointsViews = viewsRegistry.GetElements<AsciiDocEndpointsView>();

        var apiModelViews = viewsRegistry.GetElements<AsciiDocApiModelsView>();

        var viewsPath = Path.Combine(path, "Models/RestApi");

        var endpointsOutput = new AsciiDocHRApiEndpointsFileSystemViewsOutput(viewsPath, viewsRegistry);
        new AsciiDocEndpointsViewGenerator(endpointsOutput).Generate(endpointsViews);

        var modelsOutput = new AsciiDocHRApiApiModelsFileSystemViewsOutput(viewsPath, viewsRegistry);
        new AsciiDocApiModelsViewGenerator(modelsOutput).Generate(apiModelViews);
    }

    private static void GenerateOpenApiRestApiViews(
        string path,
        ViewsRegistry viewsRegistry)
    {
        var viewsPath = Path.Combine(path, "Models/RestApi");

        var views = viewsRegistry.GetElements<OpenApiView>();
        new OpenApiViewGenerator(new JsonOpenApiFileSystemViewsOutput(viewsPath, viewsRegistry)).Generate(views);
        new OpenApiYamlViewGenerator(new YamlApiFileSystemViewsOutput(viewsPath, viewsRegistry)).Generate(views);
    }
}