using Modeler.Attributes;

namespace Modeler.ConceptualModel.Sample.TestModel;

public class Gender : EnumerationType
{
    public static EnumerationType Create() => new Gender()
        .WithName("Gender")
        .WithValues("Male", "Female");
}