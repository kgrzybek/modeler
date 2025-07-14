using Modeler.ComponentsModel;
using Models.Elements;

namespace Modeler.Full.Sample.Components;

public class SystemComponentsModel : Model
{
    private static SystemComponentsModel? _instance;

    public SystemComponentsModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
    }

    public static SystemComponentsModel GetInstance(ModelElementsRegistry elementsRegistry)
    {
        if (_instance == null)
        {
            _instance = new SystemComponentsModel(elementsRegistry);
        }

        return _instance;
    }
}