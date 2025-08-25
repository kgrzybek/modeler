using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.AsciiDoc;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.AsciiDocViews;

public class OrganizationUnitAsciiDocView
{
    public const string Id = "OrganizationUnit";
    
    public static AsciiDocView Create(Model model)
    {
        var concept = model.GetEntity<OrganizationUnit>();
        
        var view = new AsciiDocView(Id, concept);

        return view;
    }
}