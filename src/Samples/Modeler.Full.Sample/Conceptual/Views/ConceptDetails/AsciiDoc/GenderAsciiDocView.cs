using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Enums;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

public class GenderAsciiDocView : AsciiDocConceptDetailsView
{
    public GenderAsciiDocView(Model model) : base(model.GetType<Gender>())
    {
    }
}