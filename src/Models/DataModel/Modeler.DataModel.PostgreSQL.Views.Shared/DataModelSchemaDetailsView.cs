using Modeler.DataModel.Schemas;
using Models.Elements;

namespace Modeler.DataModel.PostgreSQL.Views.Shared;

public abstract class DataModelSchemaDetailsView : IView
{
    public Schema Schema { get; protected init; } = null!;
}