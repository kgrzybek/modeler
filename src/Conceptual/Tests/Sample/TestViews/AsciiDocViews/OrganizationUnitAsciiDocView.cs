using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Views.AsciiDoc;

namespace Modeler.ConceptualModel.Sample.TestViews.AsciiDocViews;

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