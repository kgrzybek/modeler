using Modeler.ConceptualModel;
using Models.Elements;

namespace Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

public abstract class AsciiDocConceptDetailsView : IView
{
    protected AsciiDocConceptDetailsView(Concept concept)
    {
        Concept = concept;
    }
    
    public Concept Concept { get; }
}