using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Concepts.Entities;
using Modeler.ConceptualModel.Views.Markdown;

namespace Modeler.ConceptualModel.Sample.Views.MarkdownViews;

public class ManagerMarkdownView : MarkdownViewDefinition
{
    public const string Id = "Manager";
    
    public static MarkdownView Create(Model model)
    {
        var concept = model.GetEntity<Manager>();
        
        var view = new MarkdownView(Id, concept);

        return view;
    }
}
