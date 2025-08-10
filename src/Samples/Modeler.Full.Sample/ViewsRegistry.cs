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
        var instance = GetInstance();
        instance.AddElement(BasicSequenceView.Create(modelsRegistry.GetModel<HRSequencesModel>()));
        instance.AddElement(BasicSequencePartView.Create(modelsRegistry.GetModel<HRSequencesModel>()));
    }
}