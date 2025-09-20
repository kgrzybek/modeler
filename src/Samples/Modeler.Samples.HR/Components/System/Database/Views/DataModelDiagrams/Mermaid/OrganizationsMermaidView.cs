using Modeler.Models.Data;
using Modeler.Samples.HR.Components.System.Database.Structure.Tables;
using Modeler.Views.Data.DataModelDiagrams.Mermaid;

namespace Modeler.Samples.HR.Components.System.Database.Views.DataModelDiagrams.Mermaid;

public class OrganizationsMermaidView : MermaidDataModelView
{
    public OrganizationsMermaidView(DatabaseComponent model)
    {
        VisibleStructureElements =
        [
            new VisibleStructureElement(model.GetTable<EmployeesTable>()),
            new VisibleStructureElement(model.GetTable<OrganizationUnitTable>())
        ];
    }
}
