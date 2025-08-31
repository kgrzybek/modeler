using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Enums;
using Modeler.Views.Conceptual.ConceptDetails.Markdown;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.Markdown;

public class GenderMarkdownView : MarkdownConceptDetailsView
{
    public GenderMarkdownView(Model model) : base(model.GetType<Gender>())
    {
    }
}
