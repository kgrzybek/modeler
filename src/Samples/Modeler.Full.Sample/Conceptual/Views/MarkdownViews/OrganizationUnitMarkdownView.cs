using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.Markdown;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.MarkdownViews;

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
