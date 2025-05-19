using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Concepts.Entities;
using Modeler.ConceptualModel.Views.AsciiDoc;

namespace Modeler.ConceptualModel.Sample.Views.AsciiDocViews;

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