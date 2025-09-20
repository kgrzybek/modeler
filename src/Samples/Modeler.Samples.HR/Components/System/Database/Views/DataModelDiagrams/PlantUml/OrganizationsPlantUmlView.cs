using Modeler.Models.Data;
using Modeler.Samples.HR.Components.System.Database.Structure.Tables;
using Modeler.Views.Data.DataModelDiagrams.PlantUml;

namespace Modeler.Samples.HR.Components.System.Database.Views.DataModelDiagrams.PlantUml;

public class OrganizationsPlantUmlView : PlantUmlDataModelView
{

    public OrganizationsPlantUmlView(DatabaseComponent model)
    {
        VisibleStructureElements =
        [
            new VisibleStructureElement(model.GetTable<EmployeesTable>()),
            new VisibleStructureElement(model.GetTable<OrganizationUnitTable>())
        ];
    }
}