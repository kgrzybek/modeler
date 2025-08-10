using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.AsciiDoc;
using Modeler.Full.Sample.Conceptual.Concepts.Types;

namespace Modeler.Full.Sample.Conceptual.Views.AsciiDocViews;

public class AddressAsciiDocView : AsciiDocViewDefinition
{
    public const string Id = "Address";
    
    public static AsciiDocView Create(Model model)
    {
        var concept = model.GetType<Address>();
        
        var view = new AsciiDocView(Id, concept);

        return view;
    }
}