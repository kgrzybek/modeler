namespace Modeler.DataModel.Sample.Structure;

public class HRDataModel : DataModel
{
    private static HRDataModel? _instance;

    public static HRDataModel GetInstance()
    {
        if (_instance == null)
        {
            _instance = new HRDataModel();
        }

        return _instance;
    }
}