using Modeler.DataModel.PostgreSQL.Views.PlantUml;
using Modeler.Full.Sample.Data.Structure.Tables;

namespace Modeler.Full.Sample.Data.Views;

public class OrganizationsPlantUmlView : PlantUmlDataModelView
{

    public OrganizationsPlantUmlView(DataModel.DataModel model)
    {
        VisibleStructureElements =
        [
            new VisibleStructureElement(model.GetTable<EmployeesTable>()),
            new VisibleStructureElement(model.GetTable<OrganizationUnitTable>())
        ];
    }
    // public static PlantUmlDataModelView Create(DataModel.DataModel model)
    // {
    //     var visibleTables = new List<VisibleStructureElement>();
    //
    //     visibleTables.Add(new VisibleStructureElement(model.GetTable<EmployeesTable>()));
    //     visibleTables.Add(new VisibleStructureElement(model.GetTable<OrganizationUnitTable>()));
    //     
    //     return new PlantUmlDataModelView(visibleTables, "Models/Data/Organizations_data_model.puml");
    // }
}