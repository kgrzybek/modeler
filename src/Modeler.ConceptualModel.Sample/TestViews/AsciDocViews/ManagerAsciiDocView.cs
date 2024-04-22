using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Views.AsciiDoc;

namespace Modeler.ConceptualModel.Sample.TestViews.AsciDocViews;

public class ManagerAsciiDocView : AsciiDocViewDefinition
{
    public const string Id = "Manager";
    
    public static AsciiDocView Create(Model model)
    {
        var concept = model.GetEntity<Manager>();
        
        var view = new AsciiDocView(Id, concept);

        return view;
    }
}