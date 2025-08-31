using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Entities;
using Modeler.Views.Conceptual.ConceptDetails.Markdown;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDetails.Markdown;

public class OrganizationUnitMarkdownView : MarkdownConceptDetailsView
{
    public OrganizationUnitMarkdownView(Model model) : base(model.GetEntity<OrganizationUnit>())
    {
    }
}
