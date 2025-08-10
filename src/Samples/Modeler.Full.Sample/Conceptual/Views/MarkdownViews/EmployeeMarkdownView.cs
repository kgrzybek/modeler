using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.MarkdownViews;

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
