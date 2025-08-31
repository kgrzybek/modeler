using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;
using Modeler.Views.Conceptual.ConceptDetails.Markdown;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.Markdown;

public class EmployeeMarkdownView : MarkdownConceptDetailsView
{
    public EmployeeMarkdownView(Model model) : base(model.GetEntity<Employee>())
    {
    }
}
