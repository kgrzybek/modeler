using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Types;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDetails.AsciiDoc;

public class AddressAsciiDocView : AsciiDocConceptDetailsView
{
    public AddressAsciiDocView(Model model) : base(model.GetType<Address>())
    {
    }
}