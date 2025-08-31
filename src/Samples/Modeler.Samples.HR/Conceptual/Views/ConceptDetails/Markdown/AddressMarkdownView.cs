using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Types;
using Modeler.Views.Conceptual.ConceptDetails.Markdown;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDetails.Markdown;

public class AddressMarkdownView : MarkdownConceptDetailsView
{
    public AddressMarkdownView(Model model) : base(model.GetType<Address>())
    {
    }
}
