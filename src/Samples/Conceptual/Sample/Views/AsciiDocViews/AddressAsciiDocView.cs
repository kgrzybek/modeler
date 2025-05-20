using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Concepts.Types;
using Modeler.ConceptualModel.Views.AsciiDoc;

namespace Modeler.ConceptualModel.Sample.Views.AsciiDocViews;

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