using Modeler.SequenceModel;
using Models.Elements;

namespace Modeler.Full.Sample.Sequences;

public class HRSequencesModel : Model
{
    private static HRSequencesModel? _instance;

    private HRSequencesModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
    }

    public static HRSequencesModel GetInstance(ElementsRegistry elementsRegistry)
    {
        if (_instance == null)
        {
            _instance = new HRSequencesModel(elementsRegistry);
        }

        return _instance;
    }
}