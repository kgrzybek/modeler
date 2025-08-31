using Modeler.Full.Sample.Data.Structure.Tables;
using Modeler.Views.Data.DataModelDiagrams.PlantUml;

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