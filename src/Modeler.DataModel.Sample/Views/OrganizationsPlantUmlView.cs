using Modeler.DataModel.PostgreSQL.Views.PlantUml;

namespace Modeler.DataModel.Sample.Views;

public class OrganizationsPlantUmlView : PlantUmlDataModelViewFactory
{
    public static PlantUmlDataModelView Create(DataModel model)
    {
        var visibleTables = new List<VisibleStructureElement>();

        visibleTables.Add(new VisibleStructureElement(model.GetTable<EmployeesTable>()));
        visibleTables.Add(new VisibleStructureElement(model.GetTable<OrganizationUnitTable>()));
        
        return new PlantUmlDataModelView(visibleTables, "Models/Data/Organizations_data_model.puml");
    }
}