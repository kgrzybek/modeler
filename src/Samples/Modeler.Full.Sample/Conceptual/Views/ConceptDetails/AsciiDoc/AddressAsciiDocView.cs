using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.AsciiDoc.ConceptDetails;
using Modeler.Full.Sample.Conceptual.Concepts.Types;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

public class AddressAsciiDocView : AsciiDocConceptDetailsView
{
    public AddressAsciiDocView(Model model) : base(model.GetType<Address>())
    {
    }
}