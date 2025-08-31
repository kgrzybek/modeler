using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;
using Modeler.Views.Conceptual.ConceptDetails.Markdown;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.Markdown;

public class OrganizationUnitMarkdownView : MarkdownConceptDetailsView
{
    public OrganizationUnitMarkdownView(Model model) : base(model.GetEntity<OrganizationUnit>())
    {
    }
}
