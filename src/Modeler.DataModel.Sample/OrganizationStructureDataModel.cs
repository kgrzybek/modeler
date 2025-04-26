namespace Modeler.DataModel.Sample;

public class OrganizationStructureDataModel : DataModel
{
    private static OrganizationStructureDataModel? _instance;

    public static OrganizationStructureDataModel GetInstance()
    {
        if (_instance == null)
        {
            _instance = new OrganizationStructureDataModel();
        }

        return _instance;
    }
}