using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Views.AsciiDoc;

namespace Modeler.ConceptualModel.Sample.TestViews.AsciiDocViews;

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