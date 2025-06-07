using Modeler.ConceptualModel.Sample.Concepts;
using Modeler.ConceptualModel.Sample.Concepts.Entities;
using Modeler.ConceptualModel.Views.Markdown;

namespace Modeler.ConceptualModel.Sample.Views.MarkdownViews;

public class OrganizationUnitMarkdownView : MarkdownViewDefinition
{
    public const string Id = "OrganizationUnit";
    
    public static MarkdownView Create(Model model)
    {
        var concept = model.GetEntity<OrganizationUnit>();
        
        var view = new MarkdownView(Id, concept);

        return view;
    }
}
