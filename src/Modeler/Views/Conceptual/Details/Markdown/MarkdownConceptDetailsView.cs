using Modeler.Models.Common;
using Modeler.Models.Conceptual;
using Modeler.Views.Common;

namespace Modeler.Views.Conceptual.ConceptDetails.Markdown;

public class MarkdownConceptDetailsView : IView
{
    protected MarkdownConceptDetailsView(Concept concept)
    {
        Concept = concept;
    }
    
    public Concept Concept { get; }
}
