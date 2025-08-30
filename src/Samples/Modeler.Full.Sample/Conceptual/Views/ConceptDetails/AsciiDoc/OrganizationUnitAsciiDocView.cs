using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.AsciiDoc.ConceptDetails;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

public class OrganizationUnitAsciiDocView : AsciiDocConceptDetailsView
{
    public OrganizationUnitAsciiDocView(Model model) : base(model.GetEntity<OrganizationUnit>())
    {
    }
}