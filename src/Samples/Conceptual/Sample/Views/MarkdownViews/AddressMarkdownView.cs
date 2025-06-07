using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Concepts.Types;
using Modeler.ConceptualModel.Views.Markdown;

namespace Modeler.ConceptualModel.Sample.Views.MarkdownViews;

public class AddressMarkdownView : MarkdownViewDefinition
{
    public const string Id = "Address";
    
    public static MarkdownView Create(Model model)
    {
        var concept = model.GetType<Address>();
        
        var view = new MarkdownView(Id, concept);

        return view;
    }
}
