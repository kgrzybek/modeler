using Models.Elements;

namespace Modeler.ComponentsModel.Sample.Components;

public class SystemComponentsModel : Model
{
    private static SystemComponentsModel? _instance;

    private SystemComponentsModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
    }

    public static SystemComponentsModel GetInstance(ElementsRegistry elementsRegistry)
    {
        if (_instance == null)
        {
            _instance = new SystemComponentsModel(elementsRegistry);
        }

        return _instance;
    }
}