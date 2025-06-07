namespace Modeler.RestApiModel.Sample.Models;

public class HRRestApiModel : Model
{
    private static HRRestApiModel? _instance;

    public static HRRestApiModel GetInstance()
    {
        if (_instance == null)
        {
            _instance = new HRRestApiModel();
        }

        return _instance;
    }
}
