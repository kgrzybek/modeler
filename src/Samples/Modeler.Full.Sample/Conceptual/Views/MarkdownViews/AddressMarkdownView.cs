using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.Full.Sample.Conceptual.Concepts.Types;

namespace Modeler.Full.Sample.Conceptual.Views.MarkdownViews;

public class AddressMarkdownView
{
    public const string Id = "Address";
    
    public static MarkdownView Create(Model model)
    {
        var concept = model.GetType<Address>();
        
        var view = new MarkdownView(Id, concept);

        return view;
    }
}
