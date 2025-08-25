using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.MarkdownViews;

public class ManagerMarkdownView
{
    public const string Id = "Manager";
    
    public static MarkdownView Create(Model model)
    {
        var concept = model.GetEntity<Manager>();
        
        var view = new MarkdownView(Id, concept);

        return view;
    }
}
