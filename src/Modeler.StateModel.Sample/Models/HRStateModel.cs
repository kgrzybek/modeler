namespace Modeler.StateModel.Sample.Models;

public class HRStateModel : Model
{
    private static HRStateModel? _instance;

    public static HRStateModel GetInstance()
    {
        if (_instance == null)
        {
            _instance = new HRStateModel();
        }

        return _instance;
    }
}