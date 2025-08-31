using Modeler.ConceptualModel;
using Models.Elements;

namespace Modeler.Views.Conceptual.ConceptDetails.Markdown;

public class MarkdownConceptDetailsView : IView
{
    protected MarkdownConceptDetailsView(Concept concept)
    {
        Concept = concept;
    }
    
    public Concept Concept { get; }
}
