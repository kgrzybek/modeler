using Modeler.DataModel.PostgreSQL.Views.PlantUml;
using Modeler.Full.Sample.Data.Structure.Tables;

namespace Modeler.Full.Sample.Data.Views;

public class OrganizationsPlantUmlView
{
    public static PlantUmlDataModelView Create(DataModel.DataModel model)
    {
        var visibleTables = new List<VisibleStructureElement>();

        visibleTables.Add(new VisibleStructureElement(model.GetTable<EmployeesTable>()));
        visibleTables.Add(new VisibleStructureElement(model.GetTable<OrganizationUnitTable>()));
        
        return new PlantUmlDataModelView(visibleTables, "Models/Data/Organizations_data_model.puml");
    }
}