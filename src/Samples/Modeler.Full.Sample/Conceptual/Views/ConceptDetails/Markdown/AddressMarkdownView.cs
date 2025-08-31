using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Types;
using Modeler.Views.Conceptual.ConceptDetails.Markdown;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.Markdown;

public class AddressMarkdownView : MarkdownConceptDetailsView
{
    public AddressMarkdownView(Model model) : base(model.GetType<Address>())
    {
    }
}
