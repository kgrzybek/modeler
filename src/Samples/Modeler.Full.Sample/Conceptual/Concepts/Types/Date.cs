using Modeler.ConceptualModel.Attributes;

namespace Modeler.Full.Sample.Conceptual.Concepts.Types;

public class Date : PrimitiveType
{
    public static PrimitiveType Create() => new Date().WithName("Date");
}