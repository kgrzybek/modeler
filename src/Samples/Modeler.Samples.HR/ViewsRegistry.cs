using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Samples.HR.Apis;
using Modeler.Samples.HR.Apis.Views.AsciiDoc;
using Modeler.Samples.HR.Apis.Views.OpenApi;
using Modeler.Samples.HR.Components;
using Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;
using Modeler.Samples.HR.Components.Views.Details.AsciiDoc;
using Modeler.Samples.HR.Components.Views.Details.Markdown;
using Modeler.Samples.HR.Conceptual.Concepts;
using Modeler.Samples.HR.Conceptual.Views.ConceptDetails.AsciiDoc;
using Modeler.Samples.HR.Conceptual.Views.ConceptDetails.Markdown;
using Modeler.Samples.HR.Conceptual.Views.ConceptDiagrams;
using Modeler.Samples.HR.Data.Structure;
using Modeler.Samples.HR.Data.Views.DataModelDiagrams.Mermaid;
using Modeler.Samples.HR.Data.Views.DataModelDiagrams.PlantUml;
using Modeler.Samples.HR.Data.Views.SchemaDetails;
using Modeler.Samples.HR.Data.Views.Sql;
using Modeler.Samples.HR.EventsFlow;
using Modeler.Samples.HR.EventsFlow.Views.EventsFlowDiagrams.Mermaid;
using Modeler.Samples.HR.EventsFlow.Views.TableList.AsciiDoc;
using Modeler.Samples.HR.EventsFlow.Views.TableList.Markdown;
using Modeler.Samples.HR.Sequences;
using Modeler.Samples.HR.Sequences.Views;
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
        
        AddElement(new AsciiDocBackendComponentDetailsView(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(new AsciiDocFrontendComponentDetailsView(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(new MarkdownBackendComponentDetailsView(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(new MarkdownFrontendComponentDetailsView(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(new PlantUmlHRSystemContextView(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(new PlantUmlHRSystemComponentsView(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(new PlantUmlHRSystemModulesView(modelsRegistry.GetModel<SystemComponentsModel>()));
        
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
        
        AddElement(new OrganizationsMermaidView(modelsRegistry.GetModel<HRDataModel>()));
        AddElement(new OrganizationsPlantUmlView(modelsRegistry.GetModel<HRDataModel>()));
        AddElement(new OrganizationsSchemaDetailsView(modelsRegistry.GetModel<HRDataModel>()));
        AddElement(new SqlEmployeesTableView(modelsRegistry.GetModel<HRDataModel>()));
        AddElement(new SqlOrganizationUnitTableView(modelsRegistry.GetModel<HRDataModel>()));

        AddElement(new AbsenceStateMachineAsciiDocTableViewDefinition(modelsRegistry.GetModel<HRStateStateMachineModel>()));
        AddElement(new AbsenceStateMachineMarkdownTableViewDefinition(modelsRegistry.GetModel<HRStateStateMachineModel>()));
        AddElement(new PlantUmlAbsenceStateMachineDiagramView(modelsRegistry.GetModel<HRStateStateMachineModel>()));
        
        AddElement(new AsciiDocHREventsFlowView(modelsRegistry.GetModel<HREventsFlowModel>()));
        AddElement(new MarkdownHREventsFlowView(modelsRegistry.GetModel<HREventsFlowModel>()));
        AddElement(new HREventsFlowDiagramView(modelsRegistry.GetModel<HREventsFlowModel>()));
        
        AddElement(new ApiModelsAsciiDocViewDefinition(elementsRegistry.GetElement<HRRestApiModel>()));
        AddElement(new EndpointsAsciiDocViewDefinition(elementsRegistry));
        
        AddElement(new HROpenApiViewDefinition(elementsRegistry));
    }
}