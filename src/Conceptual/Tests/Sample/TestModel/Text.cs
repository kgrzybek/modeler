using Modeler.ConceptualModel.Attributes;

namespace Modeler.ConceptualModel.Sample.TestModel;

public class Text : PrimitiveType
{
    public static PrimitiveType Create() => new Text().WithName("Text");
}