using Modeler.ConceptualModel.Attributes;

namespace Modeler.ConceptualModel.Sample.TestModel;

public class Address : ComplexAttributeType
{
    public static ComplexAttributeType Create() => new Address()
        .WithName("Address")
        .WithAttribute("Street", Text.Create())
        .WithAttribute("HouseNumber", Text.Create())
        .WithAttribute("ApartmentNumber", Text.Create())
        .WithAttribute("City", Text.Create())
        .WithAttribute("Country", Text.Create());
}