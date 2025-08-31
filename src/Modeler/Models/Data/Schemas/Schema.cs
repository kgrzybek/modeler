using Models.Elements;

namespace Modeler.DataModel.Schemas;

public abstract class Schema : IElement
{
    public string Name { get; set; } = string.Empty;
    public string Id { get; protected set; }
}