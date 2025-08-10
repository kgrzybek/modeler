using Modeler.Full.Sample.Components;
using Modeler.Full.Sample.Components.Views;
using Modeler.Full.Sample.Components.Views.AsciiDoc.Details;
using Modeler.Full.Sample.Components.Views.Markdown.Details;
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
    }
}