using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.AsciiDoc;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.AsciiDocViews;

public class EmployeeAsciiDocView
{
    public const string Id = "Employee";
    
    public static AsciiDocView Create(Model model)
    {
        var concept = model.GetEntity<Employee>();
        
        var view = new AsciiDocView(Id, concept);

        return view;
    }
}