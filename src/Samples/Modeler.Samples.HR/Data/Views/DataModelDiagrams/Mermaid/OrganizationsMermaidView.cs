using Modeler.Models.Data;
using Modeler.Samples.HR.Data.Structure.Tables;
using Modeler.Views.Data.DataModelDiagrams.Mermaid;

namespace Modeler.Samples.HR.Data.Views.DataModelDiagrams.Mermaid;

public class OrganizationsMermaidView : MermaidDataModelView
{
    public OrganizationsMermaidView(DataModel model)
    {
        VisibleStructureElements =
        [
            new VisibleStructureElement(model.GetTable<EmployeesTable>()),
            new VisibleStructureElement(model.GetTable<OrganizationUnitTable>())
        ];
    }
}
