using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Types;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

public class AddressAsciiDocView : AsciiDocConceptDetailsView
{
    public AddressAsciiDocView(Model model) : base(model.GetType<Address>())
    {
    }
}