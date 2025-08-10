using Modeler.Full.Sample.Sequences;
using Models.Elements;

namespace Modeler.Full.Sample;

public class ModelsRegistry : ModelsRegistryBase
{
    private static ModelsRegistry? _instance;

    public static ModelsRegistry GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ModelsRegistry();
        }

        return _instance;
    }
    
    public void RegisterModels(ElementsRegistry elementsRegistry)
    {
        var instance = GetInstance(); 
        instance.AddElement(new HRSequencesModel(elementsRegistry));
    }
}