using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Entities;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDetails.AsciiDoc;

public class ManagerAsciiDocView : AsciiDocConceptDetailsView
{
    public ManagerAsciiDocView(Model model) : base(model.GetEntity<Manager>())
    {
    }
}