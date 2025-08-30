using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.ConceptualModel.Views.Markdown.ConceptDetails;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.MarkdownViews;

public class ManagerMarkdownView : MarkdownConceptDetailsView
{
    public ManagerMarkdownView(Model model) : base(model.GetEntity<Manager>())
    {
    }
}
