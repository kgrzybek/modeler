using Modeler.Models.Conceptual.Attributes;

namespace Modeler.Samples.HR.Conceptual.Concepts.Types;

public class Text : PrimitiveType
{
    public static PrimitiveType Create() => new Text().WithName("Text");
}