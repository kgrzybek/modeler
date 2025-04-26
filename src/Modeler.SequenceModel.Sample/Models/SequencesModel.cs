namespace Modeler.SequenceModel.Sample.Models;

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