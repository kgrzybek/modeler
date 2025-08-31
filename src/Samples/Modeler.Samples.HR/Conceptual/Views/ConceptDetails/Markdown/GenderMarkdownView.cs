using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Enums;
using Modeler.Views.Conceptual.ConceptDetails.Markdown;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDetails.Markdown;

public class GenderMarkdownView : MarkdownConceptDetailsView
{
    public GenderMarkdownView(Model model) : base(model.GetType<Gender>())
    {
    }
}
