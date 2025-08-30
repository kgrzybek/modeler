using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown.ConceptDetails;
using Modeler.Full.Sample.Conceptual.Concepts.Enums;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.Markdown;

public class GenderMarkdownView : MarkdownConceptDetailsView
{
    public GenderMarkdownView(Model model) : base(model.GetType<Gender>())
    {
    }
}
