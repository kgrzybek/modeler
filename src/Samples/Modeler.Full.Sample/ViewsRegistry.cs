using Modeler.Full.Sample.Components;
using Modeler.Full.Sample.Components.Views;
using Modeler.Full.Sample.Components.Views.AsciiDoc.Details;
using Modeler.Full.Sample.Components.Views.Markdown.Details;
using Modeler.Full.Sample.Conceptual.Concepts;
using Modeler.Full.Sample.Conceptual.Views;
using Modeler.Full.Sample.Conceptual.Views.AsciiDocViews;
using Modeler.Full.Sample.Conceptual.Views.MarkdownViews;
using Modeler.Full.Sample.Sequences;
using Modeler.Full.Sample.Sequences.Views;
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
    
    public void RegisterViews(ModelsRegistry modelsRegistry)
    {
        AddElement(BasicSequenceView.Create(modelsRegistry.GetModel<HRSequencesModel>()));
        AddElement(BasicSequencePartView.Create(modelsRegistry.GetModel<HRSequencesModel>()));
        
        AddElement(AsciiDocBackendDetailsViewDefinition.Create(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(AsciiDocFrontendDetailsViewDefinition.Create(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(MarkdownBackendDetailsViewDefinition.Create(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(MarkdownFrontendDetailsViewDefinition.Create(modelsRegistry.GetModel<SystemComponentsModel>()));
        AddElement(SystemComponentsView.Create(modelsRegistry.GetModel<SystemComponentsModel>()));
        
        AddElement(AddressAsciiDocView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(EmployeeAsciiDocView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(GenderAsciiDocView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(ManagerAsciiDocView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(OrganizationUnitAsciiDocView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        
        AddElement(AddressMarkdownView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(EmployeeMarkdownView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(GenderMarkdownView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(ManagerMarkdownView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        AddElement(OrganizationUnitMarkdownView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
        
        AddElement(OrganizationStructureView.Create(modelsRegistry.GetModel<OrganizationStructureConceptualModel>()));
    }
}