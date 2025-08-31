using Models.Elements;

namespace Modeler.ConceptualModel.Views.Markdown.ConceptDetails;

public class MarkdownConceptDetailsView : IView
{
    protected MarkdownConceptDetailsView(Concept concept)
    {
        Concept = concept;
    }
    
    public Concept Concept { get; }
}
