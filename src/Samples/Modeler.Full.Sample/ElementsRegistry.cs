using Modeler.Full.Sample.Apis;
using Modeler.Full.Sample.Components;
using Modeler.Full.Sample.Conceptual.Concepts;
using Modeler.Full.Sample.Sequences;
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

    public void RegisterElements()
    {
        this.RegisterHRApiElements();
        this.RegisterComponents();
        this.RegisterSequences();
        this.RegisterConcepts();
    }
}