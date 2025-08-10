using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.Full.Sample.Conceptual.Concepts.Enums;

namespace Modeler.Full.Sample.Conceptual.Views.MarkdownViews;

public class GenderMarkdownView : MarkdownViewDefinition
{
    public const string Id = "Gender";
    
    public static MarkdownView Create(Model model)
    {
        var concept = model.GetType<Gender>();
        
        var view = new MarkdownView(Id, concept);

        return view;
    }
}
