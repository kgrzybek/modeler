using Modeler.Models.Common.Elements;
using Modeler.Models.Data.Schemas;

namespace Modeler.Models.Data.Structure;

public abstract class StructureElement : IElement
{
    public string Name { get; protected set; } = string.Empty;
    public string Id { get; protected set; } = string.Empty;

    public Schema Schema { get; protected set; } = new NoSchema();
}