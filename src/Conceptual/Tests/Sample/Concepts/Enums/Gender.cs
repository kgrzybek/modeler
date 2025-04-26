using Modeler.ConceptualModel.Attributes;

namespace Modeler.ConceptualModel.Sample.Concepts.Enums;

public class Gender : EnumerationType
{
    public static EnumerationType Create() => new Gender()
        .WithName("Gender")
        .WithValues("Male", "Female");
}