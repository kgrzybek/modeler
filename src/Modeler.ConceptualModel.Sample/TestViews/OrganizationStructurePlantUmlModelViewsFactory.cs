using Modeler.ConceptualModel.Views.PlantUml.PlantUml;

namespace Modeler.ConceptualModel.Sample.TestViews;

public class OrganizationStructurePlantUmlModelViewsFactory : PlantUmlModelViewsFactory
{
    private static OrganizationStructurePlantUmlModelViewsFactory? _instance;

    public static OrganizationStructurePlantUmlModelViewsFactory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new OrganizationStructurePlantUmlModelViewsFactory();
        }

        return _instance;
    }
}