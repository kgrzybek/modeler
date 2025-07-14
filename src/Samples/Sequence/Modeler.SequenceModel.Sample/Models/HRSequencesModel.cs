using Models.Elements;

namespace Modeler.SequenceModel.Sample.Models;

public class HRSequencesModel : Model
{
    private static HRSequencesModel? _instance;

    public HRSequencesModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
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