using Modeler.Models.Common;
using Modeler.Models.Conceptual;
using Modeler.Views.Common;

namespace Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

public abstract class AsciiDocConceptDetailsView : IView
{
    protected AsciiDocConceptDetailsView(Concept concept)
    {
        Concept = concept;
    }
    
    public Concept Concept { get; }
}