using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.ConceptualModel.Views.Markdown.ConceptDetails;
using Modeler.Full.Sample.Conceptual.Concepts.Enums;
using Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

namespace Modeler.Full.Sample.Conceptual.Views.MarkdownViews;

public class GenderMarkdownView : MarkdownConceptDetailsView
{
    public GenderMarkdownView(Model model) : base(model.GetType<Gender>())
    {
    }
}
