using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Concepts.Entities;
using Modeler.ConceptualModel.Views.AsciiDoc;

namespace Modeler.ConceptualModel.Sample.Views.AsciiDocViews;

public class OrganizationUnitAsciiDocView : AsciiDocViewDefinition
{
    public const string Id = "OrganizationUnit";
    
    public static AsciiDocView Create(Model model)
    {
        var concept = model.GetEntity<OrganizationUnit>();
        
        var view = new AsciiDocView(Id, concept);

        return view;
    }
}