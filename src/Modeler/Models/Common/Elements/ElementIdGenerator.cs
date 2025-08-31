namespace Modeler.Models.Common.Elements;

public static class ElementIdGenerator
{
    public static string GenerateElementId(Type type, string elementName)
    {
        return $"{type.Name}";
    }
}