using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.ConceptualModel.Views.Markdown.ConceptDetails;
using Modeler.Full.Sample.Conceptual.Concepts.Types;

namespace Modeler.Full.Sample.Conceptual.Views.MarkdownViews;

public class AddressMarkdownView : MarkdownConceptDetailsView
{
    public AddressMarkdownView(Model model) : base(model.GetType<Address>())
    {
    }
}
