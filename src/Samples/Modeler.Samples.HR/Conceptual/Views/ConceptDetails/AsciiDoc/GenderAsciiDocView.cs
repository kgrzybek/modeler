using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Enums;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDetails.AsciiDoc;

public class GenderAsciiDocView : AsciiDocConceptDetailsView
{
    public GenderAsciiDocView(Model model) : base(model.GetType<Gender>())
    {
    }
}