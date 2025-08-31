using Modeler.Models.Data;
using Modeler.Samples.HR.Data.Structure.Tables;
using Modeler.Views.Data.DataModelDiagrams.PlantUml;

namespace Modeler.Samples.HR.Data.Views.DataModelDiagrams.PlantUml;

public class OrganizationsPlantUmlView : PlantUmlDataModelView
{

    public OrganizationsPlantUmlView(DataModel model)
    {
        VisibleStructureElements =
        [
            new VisibleStructureElement(model.GetTable<EmployeesTable>()),
            new VisibleStructureElement(model.GetTable<OrganizationUnitTable>())
        ];
    }
}