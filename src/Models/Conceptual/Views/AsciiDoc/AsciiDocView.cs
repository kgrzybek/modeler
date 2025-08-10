using Models.Elements;

namespace Modeler.ConceptualModel.Views.AsciiDoc;

public class AsciiDocView : IView
{
    public AsciiDocView(string id, Concept concept)
    {
        Concept = concept;
        Id = id;
    }
    
    public Concept Concept { get; }
    
    public string Id { get; }
}