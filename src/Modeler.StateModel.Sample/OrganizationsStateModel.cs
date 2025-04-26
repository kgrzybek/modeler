namespace Modeler.StateModel.Sample;

public class OrganizationsStateModel : Model
{
    private static OrganizationsStateModel? _instance;

    public static OrganizationsStateModel GetInstance()
    {
        if (_instance == null)
        {
            _instance = new OrganizationsStateModel();
        }

        return _instance;
    }
}