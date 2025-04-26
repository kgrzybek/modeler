namespace Modeler.SequenceModel.Tests.Sample;

public class SequencesModel : Model
{
    private static SequencesModel? _instance;

    public static SequencesModel GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SequencesModel();
        }

        return _instance;
    }
}