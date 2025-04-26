using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Concepts.Entities;
using Modeler.ConceptualModel.Views.AsciiDoc;

namespace Modeler.ConceptualModel.Sample.Views.AsciiDocViews;

public class EmployeeAsciiDocView : AsciiDocViewDefinition
{
    public const string Id = "Employee";
    
    public static AsciiDocView Create(Model model)
    {
        var concept = model.GetEntity<Employee>();
        
        var view = new AsciiDocView(Id, concept);

        return view;
    }
}