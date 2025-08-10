using Modeler.DataModel.Schemas;
using Models.Elements;

namespace Modeler.DataModel.Structure;

public abstract class StructureElement : IElement
{
    public string Name { get; protected set; } = string.Empty;
    public string Id { get; protected set; } = string.Empty;

    public Schema Schema { get; protected set; } = new NoSchema();
}