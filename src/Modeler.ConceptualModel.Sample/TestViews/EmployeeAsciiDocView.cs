using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Views.AsciiDoc;
using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.ConceptualModel.Sample.TestViews;

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