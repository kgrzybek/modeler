using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Concepts.Enums;
using Modeler.ConceptualModel.Views.Markdown;

namespace Modeler.ConceptualModel.Sample.Views.MarkdownViews;

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
