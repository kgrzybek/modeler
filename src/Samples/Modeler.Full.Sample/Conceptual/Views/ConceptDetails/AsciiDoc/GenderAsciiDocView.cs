using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.AsciiDoc.ConceptDetails;
using Modeler.Full.Sample.Conceptual.Concepts.Enums;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

public class GenderAsciiDocView : AsciiDocConceptDetailsView
{
    public GenderAsciiDocView(Model model) : base(model.GetType<Gender>())
    {
    }
}