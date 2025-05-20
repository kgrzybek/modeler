using Modeler.ConceptualModel.Attributes;

namespace Modeler.ConceptualModel.Sample.Concepts.Types;

public class Text : PrimitiveType
{
    public static PrimitiveType Create() => new Text().WithName("Text");
}