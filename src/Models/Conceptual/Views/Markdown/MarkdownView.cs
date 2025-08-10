using Models.Elements;

namespace Modeler.ConceptualModel.Views.Markdown;

public class MarkdownView : IView
{
    public MarkdownView(string id, Concept concept)
    {
        Concept = concept;
        Id = id;
    }
    
    public Concept Concept { get; }
    
    public string Id { get; }
}
