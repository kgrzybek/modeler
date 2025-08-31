using Modeler.Models.Conceptual.Attributes;

namespace Modeler.Samples.HR.Conceptual.Concepts.Enums;

public class Gender : EnumerationType
{
    public static EnumerationType Create() => new Gender()
        .WithName("Gender")
        .WithValues("Male", "Female");
}