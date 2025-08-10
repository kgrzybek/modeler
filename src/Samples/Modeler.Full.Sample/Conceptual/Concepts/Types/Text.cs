using Modeler.ConceptualModel.Attributes;

namespace Modeler.Full.Sample.Conceptual.Concepts.Types;

public class Text : PrimitiveType
{
    public static PrimitiveType Create() => new Text().WithName("Text");
}