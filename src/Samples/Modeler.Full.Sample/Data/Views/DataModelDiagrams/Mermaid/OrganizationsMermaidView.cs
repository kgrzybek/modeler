using Modeler.DataModel.PostgreSQL.Views.Mermaid;
using Modeler.Full.Sample.Data.Structure.Tables;

namespace Modeler.Full.Sample.Data.Views.DataModelDiagrams.Mermaid;

public class OrganizationsMermaidView : MermaidDataModelView
{
    public OrganizationsMermaidView(DataModel.DataModel model)
    {
        VisibleStructureElements =
        [
            new VisibleStructureElement(model.GetTable<EmployeesTable>()),
            new VisibleStructureElement(model.GetTable<OrganizationUnitTable>())
        ];
    }
}
