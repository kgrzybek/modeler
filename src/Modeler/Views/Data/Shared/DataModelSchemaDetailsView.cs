using Modeler.DataModel.Schemas;
using Models.Elements;

namespace Modeler.Views.Data.Shared;

public abstract class DataModelSchemaDetailsView : IView
{
    public Schema Schema { get; protected init; } = null!;
}