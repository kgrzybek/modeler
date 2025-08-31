using Modeler.Models.Conceptual.Attributes;

namespace Modeler.Samples.HR.Conceptual.Concepts.Types;

public class Date : PrimitiveType
{
    public static PrimitiveType Create() => new Date().WithName("Date");
}