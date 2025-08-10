using Modeler.ConceptualModel.Attributes;

namespace Modeler.Full.Sample.Conceptual.Concepts.Types;

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