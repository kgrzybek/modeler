using Models.Elements;

namespace Modeler.Full.Sample;

public class ElementsRegistry : ModelElementsRegistry
{
    private static ElementsRegistry? _instance;

    public static ElementsRegistry GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ElementsRegistry();
        }

        return _instance;
    }
}