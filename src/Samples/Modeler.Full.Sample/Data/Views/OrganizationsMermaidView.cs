using Modeler.DataModel.PostgreSQL.Views.Mermaid;
using Modeler.Full.Sample.Data.Structure.Tables;

namespace Modeler.Full.Sample.Data.Views;

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
    
    // public static MermaidDataModelView Create(DataModel.DataModel model)
    // {
    //     var visibleTables = new List<VisibleStructureElement>();
    //
    //     visibleTables.Add(new VisibleStructureElement(model.GetTable<EmployeesTable>()));
    //     visibleTables.Add(new VisibleStructureElement(model.GetTable<OrganizationUnitTable>()));
    //
    //     return new MermaidDataModelView(visibleTables, "Models/Data/Organizations_data_model.mmd");
    // }
}
