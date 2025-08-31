using Modeler.Full.Sample.Data.Structure.Tables;
using Modeler.Views.Data.DataModelDiagrams.Mermaid;

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
