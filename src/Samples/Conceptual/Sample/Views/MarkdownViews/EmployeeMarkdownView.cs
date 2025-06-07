using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Concepts.Entities;
using Modeler.ConceptualModel.Views.Markdown;

namespace Modeler.ConceptualModel.Sample.Views.MarkdownViews;

public class EmployeeMarkdownView : MarkdownViewDefinition
{
    public const string Id = "Employee";
    
    public static MarkdownView Create(Model model)
    {
        var concept = model.GetEntity<Employee>();
        
        var view = new MarkdownView(Id, concept);

        return view;
    }
}
