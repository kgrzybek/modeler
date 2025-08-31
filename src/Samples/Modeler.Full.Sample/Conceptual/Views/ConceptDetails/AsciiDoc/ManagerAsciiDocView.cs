using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

public class ManagerAsciiDocView : AsciiDocConceptDetailsView
{
    public ManagerAsciiDocView(Model model) : base(model.GetEntity<Manager>())
    {
    }
}