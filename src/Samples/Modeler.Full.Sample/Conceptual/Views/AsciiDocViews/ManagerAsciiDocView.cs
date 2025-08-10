using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.AsciiDoc;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.AsciiDocViews;

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