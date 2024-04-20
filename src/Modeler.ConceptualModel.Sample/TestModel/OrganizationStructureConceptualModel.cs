namespace Modeler.ConceptualModel.Sample.TestModel;

public class OrganizationStructureConceptualModel : Model
{
    private static OrganizationStructureConceptualModel? _instance;

    public static OrganizationStructureConceptualModel GetInstance()
    {
        if (_instance == null)
        {
            _instance = new OrganizationStructureConceptualModel();
        }

        return _instance;
    }
}