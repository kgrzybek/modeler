using Modeler.Full.Sample.Apis;
using Modeler.Full.Sample.Apis.Views.AsciiDoc;
using Modeler.Full.Sample.Components;
using Modeler.Full.Sample.Components.Views;
using Modeler.Full.Sample.Components.Views.ComponentsDiagram.PlantUml;
using Modeler.Full.Sample.Components.Views.Details.AsciiDoc;
using Modeler.Full.Sample.Components.Views.Details.Markdown;
using Modeler.Full.Sample.Conceptual.Concepts;
using Modeler.Full.Sample.Conceptual.Views;
using Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;
using Modeler.Full.Sample.Conceptual.Views.ConceptDetails.Markdown;
using Modeler.Full.Sample.Conceptual.Views.ConceptDiagrams;
using Modeler.Full.Sample.Data.Structure;
using Modeler.Full.Sample.Data.Views;
using Modeler.Full.Sample.Data.Views.DataModelDiagrams.Mermaid;
using Modeler.Full.Sample.Data.Views.DataModelDiagrams.PlantUml;
using Modeler.Full.Sample.Data.Views.SchemaDetails;
using Modeler.Full.Sample.Data.Views.Sql;
using Modeler.Full.Sample.EventsFlow;
using Modeler.Full.Sample.EventsFlow.Views.EventsFlowDiagrams.Mermaid;
using Modeler.Full.Sample.EventsFlow.Views.TableList.AsciiDoc;
using Modeler.Full.Sample.EventsFlow.Views.TableList.Markdown;
using Modeler.Full.Sample.Sequences;
using Modeler.Full.Sample.Sequences.Views;
using Modeler.Full.Sample.State.Models;
using Modeler.Full.Sample.State.Views.AsciiDoc;
using Modeler.Full.Sample.State.Views.Markdown;
using Modeler.Full.Sample.State.Views.PlantUml;
using Models.Elements;

namespace Modeler.Full.Sample;

public class ViewsRegistry : ViewsRegistryBase
{
    private static ViewsRegistry? _instance;

    public static ViewsRegistry GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ViewsRegistry();
        }

        return _instance;
    }
    
    public void RegisterViews(ModelsRegistry modelsRegistry, ModelElementsRegistry elementsRegistry)
    {
        AddElement(BasicSequenceView.Create(modelsRegistry.GetModel<HRSequencesModel>()));
        AddElement(BasicSequencePartView.Create(modelsRegistry.GetModel<HRSequencesModel>()));
        
        AddElement(new AsciiDocBackendComponentDetailsView(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(new AsciiDocFrontendComponentDetailsView(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(new MarkdownBackendComponentDetailsView(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(new MarkdownFrontendComponentDetailsView(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(new PlantUmlHRSystemComponentsView(modelsRegistry.GetModel<SystemComponentsModel>()));
        
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

        AddElement(AbsenceStateMachineAsciiDocTableViewDefinition.Create(modelsRegistry.GetModel<HRStateStateMachineModel>()));
        AddElement(AbsenceStateMachineMarkdownTableViewDefinition.Create(modelsRegistry.GetModel<HRStateStateMachineModel>()));
        AddElement(AbsenceStateMachinePlantUmlViewDefinition.Create(modelsRegistry.GetModel<HRStateStateMachineModel>()));
        
        AddElement(new AsciiDocHREventsFlowView(modelsRegistry.GetModel<HREventsFlowModel>()));
        AddElement(new MarkdownHREventsFlowView(modelsRegistry.GetModel<HREventsFlowModel>()));
        AddElement(new HREventsFlowDiagramView(modelsRegistry.GetModel<HREventsFlowModel>()));
        
        AddElement(new ApiModelsAsciiDocViewDefinition(elementsRegistry.GetElement<HRRestApiModel>()));
        AddElement(new EndpointsAsciiDocViewDefinition(elementsRegistry));
        
        
    }
}