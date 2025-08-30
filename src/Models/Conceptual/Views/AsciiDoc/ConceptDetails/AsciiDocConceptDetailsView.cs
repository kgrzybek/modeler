using Models.Elements;

namespace Modeler.ConceptualModel.Views.AsciiDoc.ConceptDetails;

public abstract class AsciiDocConceptDetailsView : IView
{
    protected AsciiDocConceptDetailsView(Concept concept)
    {
        Concept = concept;
    }
    
    public Concept Concept { get; }
}