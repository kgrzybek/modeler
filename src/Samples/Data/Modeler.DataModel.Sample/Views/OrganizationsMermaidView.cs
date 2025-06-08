using Modeler.DataModel.PostgreSQL.Views.Mermaid;
using Modeler.DataModel.Sample.Structure.Tables;

namespace Modeler.DataModel.Sample.Views;

public class OrganizationsMermaidView : MermaidDataModelViewFactory
{
    public static MermaidDataModelView Create(DataModel model)
    {
        var visibleTables = new List<VisibleStructureElement>();

        visibleTables.Add(new VisibleStructureElement(model.GetTable<EmployeesTable>()));
        visibleTables.Add(new VisibleStructureElement(model.GetTable<OrganizationUnitTable>()));

        return new MermaidDataModelView(visibleTables, "Models/Data/Organizations_data_model.mmd");
    }
}
