using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown.ConceptDetails;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.Markdown;

public class OrganizationUnitMarkdownView : MarkdownConceptDetailsView
{
    public OrganizationUnitMarkdownView(Model model) : base(model.GetEntity<OrganizationUnit>())
    {
    }
}
