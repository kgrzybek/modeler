using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Concepts.Enums;
using Modeler.ConceptualModel.Views.AsciiDoc;

namespace Modeler.ConceptualModel.Sample.Views.AsciiDocViews;

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