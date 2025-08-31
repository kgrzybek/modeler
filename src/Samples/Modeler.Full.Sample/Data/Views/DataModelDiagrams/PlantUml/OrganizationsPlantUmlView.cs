using Modeler.DataModel.PostgreSQL.Views.PlantUml;
using Modeler.Full.Sample.Data.Structure.Tables;

namespace Modeler.Full.Sample.Data.Views.DataModelDiagrams.PlantUml;

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
}