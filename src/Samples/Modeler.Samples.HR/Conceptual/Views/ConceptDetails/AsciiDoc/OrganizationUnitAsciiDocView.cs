using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Entities;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDetails.AsciiDoc;

public class OrganizationUnitAsciiDocView : AsciiDocConceptDetailsView
{
    public OrganizationUnitAsciiDocView(Model model) : base(model.GetEntity<OrganizationUnit>())
    {
    }
}