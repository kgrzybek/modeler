using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Entities;
using Modeler.Views.Conceptual.ConceptDetails.Markdown;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDetails.Markdown;

public class ManagerMarkdownView : MarkdownConceptDetailsView
{
    public ManagerMarkdownView(Model model) : base(model.GetEntity<Manager>())
    {
    }
}
