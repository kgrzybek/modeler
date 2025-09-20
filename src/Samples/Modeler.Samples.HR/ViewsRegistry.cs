using Modeler.Models.Common.Elements;
using Modeler.Samples.HR.Components;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.ApiModelsList.AsciiDoc;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.EndpointsList.AsciiDoc;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.OpenApi;
using Modeler.Samples.HR.Components.System.Database;
using Modeler.Samples.HR.Components.System.Database.Views.DataModelDiagrams.Mermaid;
using Modeler.Samples.HR.Components.System.Database.Views.DataModelDiagrams.PlantUml;
using Modeler.Samples.HR.Components.System.Database.Views.SchemaDetails;
using Modeler.Samples.HR.Components.System.Database.Views.Sql;
using Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;
using Modeler.Samples.HR.Components.Views.Details.AsciiDoc;
using Modeler.Samples.HR.Components.Views.Details.Markdown;
using Modeler.Samples.HR.Conceptual.Concepts;
using Modeler.Samples.HR.Conceptual.Views.ConceptDetails.AsciiDoc;
using Modeler.Samples.HR.Conceptual.Views.ConceptDetails.Markdown;
using Modeler.Samples.HR.Conceptual.Views.ConceptDiagrams;
using Modeler.Samples.HR.EventsFlow;
using Modeler.Samples.HR.EventsFlow.Views.EventsFlowDiagrams.Mermaid;
using Modeler.Samples.HR.EventsFlow.Views.TableList.AsciiDoc;
using Modeler.Samples.HR.EventsFlow.Views.TableList.Markdown;
using Modeler.Samples.HR.Sequences;
using Modeler.Samples.HR.Sequences.Views;
using Modeler.Samples.HR.Sequences.Views.SequenceDiagrams;
using Modeler.Samples.HR.State.Models;
using Modeler.Samples.HR.State.Views.PlantUml;
using Modeler.Samples.HR.State.Views.StateMachineTable.AsciiDoc;
using Modeler.Samples.HR.State.Views.StateMachineTable.Markdown;
using Modeler.Views.Common;

namespace Modeler.Samples.HR;

public class ViewsRegistry : ViewsRegistryBase
{
    public void RegisterViews(ModelsRegistry modelsRegistry, ModelElementsRegistry elementsRegistry)
    {
        AddElement(new BasicSequenceView(elementsRegistry, modelsRegistry.GetModel<HRSequencesModel>()));
        AddElement(new BasicSequencePartView(elementsRegistry, modelsRegistry.GetModel<HRSequencesModel>()));
        
        AddElement(new AsciiDocBackendComponentDetailsView(modelsRegistry.GetModel<HRSystemComponentsModel>()));
        AddElement(new AsciiDocFrontendComponentDetailsView(modelsRegistry.GetModel<HRSystemComponentsModel>()));
        AddElement(new MarkdownBackendComponentDetailsView(modelsRegistry.GetModel<HRSystemComponentsModel>()));
        AddElement(new MarkdownFrontendComponentDetailsView(modelsRegistry.GetModel<HRSystemComponentsModel>()));
        AddElement(new PlantUmlHRSystemContextView(modelsRegistry.GetModel<HRSystemComponentsModel>()));
        AddElement(new PlantUmlHRSystemComponentsView(modelsRegistry.GetModel<HRSystemComponentsModel>()));
        AddElement(new PlantUmlHRSystemModulesView(modelsRegistry.GetModel<HRSystemComponentsModel>()));
        AddElement(new PlantUmlBackendModulesView(modelsRegistry.GetModel<HRSystemComponentsModel>()));
        
        AddElement(new AddressAsciiDocView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(new EmployeeAsciiDocView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(new GenderAsciiDocView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(new ManagerAsciiDocView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(new OrganizationUnitAsciiDocView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        
        AddElement(new AddressMarkdownView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(new EmployeeMarkdownView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(new GenderMarkdownView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(new ManagerMarkdownView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(new OrganizationUnitMarkdownView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        
        AddElement(new OrganizationStructureConceptsView(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        
        AddElement(new OrganizationsMermaidView(elementsRegistry.GetElement<HRDatabaseComponent>()));
        AddElement(new OrganizationsPlantUmlView(elementsRegistry.GetElement<HRDatabaseComponent>()));
        AddElement(new OrganizationsSchemaDetailsView(elementsRegistry.GetElement<HRDatabaseComponent>()));
        AddElement(new SqlEmployeesTableView(elementsRegistry.GetElement<HRDatabaseComponent>()));
        AddElement(new SqlOrganizationUnitTableView(elementsRegistry.GetElement<HRDatabaseComponent>()));

        AddElement(new AbsenceStateMachineAsciiDocTableViewDefinition(modelsRegistry.GetModel<HRStateStateMachineModel>()));
        AddElement(new AbsenceStateMachineMarkdownTableViewDefinition(modelsRegistry.GetModel<HRStateStateMachineModel>()));
        AddElement(new PlantUmlAbsenceStateMachineDiagramView(modelsRegistry.GetModel<HRStateStateMachineModel>()));
        
        AddElement(new AsciiDocHREventsFlowView(modelsRegistry.GetModel<HREventsFlowModel>()));
        AddElement(new MarkdownHREventsFlowView(modelsRegistry.GetModel<HREventsFlowModel>()));
        AddElement(new HREventsFlowDiagramView(modelsRegistry.GetModel<HREventsFlowModel>()));
        
        AddElement(new ApiModelsAsciiDocViewDefinition(elementsRegistry.GetElement<HRRestApiComponent>()));
        AddElement(new EndpointsAsciiDocViewDefinition(elementsRegistry));
        
        AddElement(new HROpenApiViewDefinition(elementsRegistry));
    }
}