using Modeler.SequenceModel;

namespace Modeler.Full.Sample.Sequences;

public class HRSequencesModel : Model
{
    private static HRSequencesModel? _instance;

    public static HRSequencesModel GetInstance()
    {
        if (_instance == null)
        {
            _instance = new HRSequencesModel();
        }

        return _instance;
    }
}