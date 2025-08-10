using Modeler.ConceptualModel.Attributes;

namespace Modeler.Full.Sample.Conceptual.Concepts.Enums;

public class Gender : EnumerationType
{
    public static EnumerationType Create() => new Gender()
        .WithName("Gender")
        .WithValues("Male", "Female");
}