using Modeler.Models.Common.Elements;

namespace Modeler.Models.Data.Schemas;

public abstract class Schema : IElement
{
    public string Name { get; set; } = string.Empty;
    public string Id { get; protected set; }
}