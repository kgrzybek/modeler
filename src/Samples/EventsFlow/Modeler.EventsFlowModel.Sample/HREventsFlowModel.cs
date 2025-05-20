namespace Modeler.EventsFlowModel.Sample;

public class HREventsFlowModel : Model
{
    private static HREventsFlowModel? _instance;

    public static HREventsFlowModel GetInstance()
    {
        if (_instance == null)
        {
            _instance = new HREventsFlowModel();
        }

        return _instance;
    }
}