using Modeler.ConceptualModel.Attributes;

namespace Modeler.ConceptualModel.Sample.Concepts.Types;

public class Date : PrimitiveType
{
    public static PrimitiveType Create() => new Date().WithName("Date");
}