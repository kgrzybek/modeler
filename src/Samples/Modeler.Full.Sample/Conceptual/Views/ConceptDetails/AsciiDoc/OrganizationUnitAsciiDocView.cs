using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

public class OrganizationUnitAsciiDocView : AsciiDocConceptDetailsView
{
    public OrganizationUnitAsciiDocView(Model model) : base(model.GetEntity<OrganizationUnit>())
    {
    }
}