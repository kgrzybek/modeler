namespace Models.Elements;

public static class ElementIdGenerator
{
    public static string GenerateElementId(Type type, string elementName)
    {
        return $"{type.Name}.{elementName}";
    }
}