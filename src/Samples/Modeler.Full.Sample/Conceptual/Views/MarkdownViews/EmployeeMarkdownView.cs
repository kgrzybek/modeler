using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.ConceptualModel.Views.Markdown.ConceptDetails;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.MarkdownViews;

public class EmployeeMarkdownView : MarkdownConceptDetailsView
{
    public EmployeeMarkdownView(Model model) : base(model.GetEntity<Employee>())
    {
    }
}
