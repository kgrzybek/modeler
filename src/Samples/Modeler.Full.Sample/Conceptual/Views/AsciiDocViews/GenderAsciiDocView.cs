using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.AsciiDoc;
using Modeler.Full.Sample.Conceptual.Concepts.Enums;

namespace Modeler.Full.Sample.Conceptual.Views.AsciiDocViews;

public class GenderAsciiDocView : AsciiDocViewDefinition
{
    public const string Id = "Gender";
    
    public static AsciiDocView Create(Model model)
    {
        var concept = model.GetType<Gender>();
        
        var view = new AsciiDocView(Id, concept);

        return view;
    }
}