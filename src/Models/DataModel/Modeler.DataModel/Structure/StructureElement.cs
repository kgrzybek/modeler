using Modeler.DataModel.Schemas;

namespace Modeler.DataModel.Structure;

public abstract class StructureElement
{
    public string Name { get; set; } = string.Empty;

    public Schema Schema { get; set; } = new NoSchema();
}