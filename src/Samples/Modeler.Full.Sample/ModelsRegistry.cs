using Modeler.Full.Sample.Components;
using Modeler.Full.Sample.Conceptual.Concepts;
using Modeler.Full.Sample.Data.Structure;
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
        AddElement(new HRSequencesModel(elementsRegistry));
        AddElement(new SystemComponentsModel(elementsRegistry));
        AddElement(new OrganizationStructureConceptualModel(elementsRegistry));
        AddElement(new HRDataModel(elementsRegistry));
    }
}